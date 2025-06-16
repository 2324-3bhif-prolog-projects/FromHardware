:- use_module(library(random)).
:- use_module(library(lists)).
:- encoding(utf8).

% Dynamische Fakten zur Speicherung des Spielzustands
% player_state(char(Name, HP, MaxHP, ArmorClass, Position, Abilities, Stress, Accuracy, DamageMod, StressMod, CharacterType)).
:- dynamic player_state/1.
% Zustand der Gebundenen Muse (für Kapitel 3)
:- dynamic muse_state/1. % muse_state(freed), muse_state(spoken), muse_state(left)
% Zustand des Helms (für Kapitel 1, Norden-Pfad)
:- dynamic player_has_helmet/0.

% --- Kampf-System Prädikate ---

% Define ability(Name, Description, TargetPositions, MinPower, MaxPower, Type, StressEffect, BuffType).
% Character: char(Name, HP, MaxHP, ArmorClass, Position, Abilities, Stress, Accuracy, DamageMod, StressMod, CharacterType).

hp_phrase_high([
    "Der Gegner wirkt selbstsicher und unbeeindruckt.",
    "Seine Haltung ist aufrecht – der Kampf hat noch kaum begonnen.",
    "Lachend fragt Minos dich ‚War das alles was du hast?‘",
    "Minos steht gähnend vor dir."
]).
hp_phrase_mid([
    "Blut tropft auf den Boden.",
    "Er beginnt zu schwanken, doch sein Blick bleibt entschlossen.",
    "Seine Bewegungen wirken langsamer.",
    "Ein Kratzen ziert die sonst makellose Oberfläche seiner Haut."
]).
hp_phrase_low([
    "Er taumelt und kann kaum noch stehen.",
    "Sein Körper zittert.",
    "Blut spritzt aus sämtlichen Körperstellen.",
    "Minos' Kinn sieht verschoben und gebrochen aus.",
    "Er wirkt wie eine Hülle seiner selbst.",
    "Er röchelt, sein Blick verschwimmt.",
    "Sein Körper ist zerfetzt, sein Wille bricht – doch noch lebt er."
]).

get_hp_phrase(CurrentHP, MaxHP, Phrase) :-
    MaxHP > 0,
    Ratio is CurrentHP / MaxHP * 100,
    ( Ratio > 70 -> hp_phrase_high(List)
    ; Ratio > 40 -> hp_phrase_mid(List)
    ; hp_phrase_low(List)
    ),
    random_member(Phrase, List).

roll(Min, Max, Roll) :- random_between(1, 20, R). % This was incorrect for non-20 rolls, fixing to use Min/Max.
roll20(R) :- random_between(1, 20, R).

% apply_buff(BuffType, Power, CharIn, CharOut, Message)
apply_buff(accuracy, Power, char(N,HP,MaxHP,AC,Pos,Abs,Str,Acc,DMod,SMod,CT),
            char(N,HP,MaxHP,AC,Pos,Abs,Str,NewAcc,DMod,SMod,CT), Msg) :-
    NewAcc is Acc + Power,
    format(string(Msg), "~w's Genauigkeit wurde um ~w erhöht. Neue Genauigkeit: ~w.", [N, Power, NewAcc]).
apply_buff(hp, Power, char(N,HP,MaxHP,AC,Pos,Abs,Str,Acc,DMod,SMod,CT),
            char(N,NewHP,NewMaxHP,AC,Pos,Abs,Str,Acc,DMod,SMod,CT), Msg) :-
    NewMaxHP is MaxHP + Power,
    TempHP is HP + Power,
    ( TempHP > NewMaxHP -> NewHP = NewMaxHP ; NewHP = TempHP ),
    format(string(Msg), "~w's maximale HP und aktuelle HP wurden um ~w erhöht. Neue HP: ~w/~w.", [N, Power, NewHP, NewMaxHP]).
apply_buff(damage, Power, char(N,HP,MaxHP,AC,Pos,Abs,Str,Acc,DMod,SMod,CT),
            char(N,HP,MaxHP,AC,Pos,Abs,Str,Acc,NewDMod,SMod,CT), Msg) :-
    NewDMod is DMod + Power,
    format(string(Msg), "~w's Schaden wurde um ~w erhöht. Neuer Schaden: ~w.", [N, Power, NewDMod]).
apply_buff(stress, Power, char(N,HP,MaxHP,AC,Pos,Abs,Str,Acc,DMod,SMod,CT),
            char(N,HP,MaxHP,AC,Pos,Abs,Str,Acc,DMod,NewSMod,CT), Msg) :-
    NewSMod is SMod + Power,
    format(string(Msg), "~w's Stress-Modifikator wurde um ~w erhöht. Neuer StressMod: ~w.", [N, Power, NewSMod]).
apply_buff(armor, Power, char(N,HP,MaxHP,AC,Pos,Abs,Str,Acc,DMod,SMod,CT),
            char(N,HP,MaxHP,NewAC,Pos,Abs,Str,Acc,DMod,SMod,CT), Msg) :-
    NewAC is AC + Power,
    format(string(Msg), "~w's Rüstungsklasse wurde um ~w erhöht. Neue Rüstungsklasse: ~w.", [N, Power, NewAC]).
apply_buff(none, _, Char, Char, Msg) :- Msg = "". % No buff/debuff applied, no message.


use_ability(User, Target, AbilityName, NewUser, NewTarget, Messages) :-
    User = char(NameU,HPu,MaxHPu,ACu,PosU,AbilitiesU,StressU,AccU,DModU,SModU,TypeU),
    Target = char(NameT,HPt,MaxHPt,ACt,PosT,AbilitiesT,StressT,AccT,DModT,SModT,TypeT),
    member(ability(AbilityName, Description, _, MinP, MaxP, TypeA, StressEffect, BuffType), AbilitiesU),
    random_between(MinP, MaxP, Power0), % Correctly use MinP/MaxP for the power roll
    ( TypeA == attack ->
        roll20(RawRoll), AttackRoll is RawRoll + AccU,
        ( AttackRoll >= ACt ->
            ( RawRoll == 20 -> PowerFloat is Power0 * 1.5 ; PowerFloat is Power0 ),
            Damage is integer(PowerFloat + DModU), % Apply user''s damage modifier here
            NewHPt is HPt - Damage,
            NewStressT is StressT + StressEffect,
            format(string(Msg1), "[Würfelergebnis: ~w + ~w (Treffer)] – ~w erleidet ~w Schaden.", [RawRoll, AccU, NameT, Damage]),
            ( NewHPt > 0 ->
                ( (TypeT == boss ; TypeT == miniboss) -> get_hp_phrase(NewHPt, MaxHPt, Phrase), Msg2 = Phrase
                ; format(string(Msg2), "~w hat noch ~w von ~w HP.", [NameT, NewHPt, MaxHPt])
                )
            ; Msg2 = "" % Target defeated
            ),
            NewTarget = char(NameT,NewHPt,MaxHPt,ACt,PosT,AbilitiesT,NewStressT,AccT,DModT,SModT,TypeT),
            NewUser = User,
            ( Msg2 == "" -> Messages = [[Msg1]]
            ; Messages = [[Msg1, Msg2]]
            )
        ; format(string(Msg), "[Würfelergebnis: ~w + ~w (Verfehlt)] – Du schwingst dein Schwert knapp an ihm vorbei.", [RawRoll, AccU]),
          NewTarget = Target,
          NewUser = User,
          Messages = [[Msg]]
        )
    ; TypeA == heal ->
        NewHPu is min(HPu + Power0, MaxHPu),
        format(string(Msg), "Du betest und erhältst ~w HP wieder.", [Power0]),
        NewUser = char(NameU,NewHPu,MaxHPu,ACu,PosU,AbilitiesU,StressU,AccU,DModU,SModU,TypeU),
        NewTarget = Target,
        Messages = [[Msg]]
    ; TypeA == buff -> % Buff applies to User
        apply_buff(BuffType, Power0, User, NewUser, BuffMsg),
        NewTarget = Target,
        Messages = [[Description, BuffMsg]]
    ; TypeA == debuff -> % Debuff applies to Target
        ( BuffType == stress -> % Debuff directly modifies stress
            % For stress debuff, Power0 is already the amount of stress to add
            NewStressT is StressT + Power0, % Power0 is the amount of stress to add
            NewTarget = char(NameT,HPt,MaxHPt,ACt,PosT,AbilitiesT,NewStressT,AccT,DModT,SModT,TypeT),
            NewUser = User,
            format(string(MsgEffect), "~w wurde von ~w getroffen. Stress um ~w erhöht, neuer Stress: ~w.", [NameT, AbilityName, Power0, NewStressT]),
            Messages = [[Description, MsgEffect]]
        ; % Other debuffs (accuracy, damage, armor, hp) - these *reduce* target stats
            Power is -Power0, % For other debuffs, Power is negative because it reduces a stat
            apply_buff(BuffType, Power, Target, NewTarget, BuffMsg),
            NewUser = User,
            Messages = [[Description, BuffMsg]]
        )
    ).

stress_out_char(char(Name,HP,MaxHP,AC,Pos,Abilities,_,Acc,DMod,SMod,CT),
                FinalChar, Messages) :-
    % 1) Finde alle buff‑ oder debuff‑Fähigkeiten
    include(is_buff_or_debuff, Abilities, All),
    ( All = [] ->
        % Falls keine Buffs/Debuffs verfügbar: Stress zurücksetzen
        TempChar = char(Name,HP,MaxHP,AC,Pos,Abilities,0,Acc,DMod,SMod,CT),
        Msgs0 = [["StressOut ausgelöst, aber keine anwendbaren Fähigkeiten gefunden. Stress zurückgesetzt."]]
    ;
        % 2) Wähle zufällig eine Fähigkeit und wende sie an
        length(All, Total),
        random_between(1, Total, I),
        nth1(I, All, ability(AbilityName, Desc,_,MinP,MaxP,TypeA,_,BuffType)),
        random_between(MinP, MaxP, Power0),
        ( TypeA == debuff -> Power is -Power0 ; Power is Power0 ),
        apply_buff(BuffType, Power,
                   char(Name,HP,MaxHP,AC,Pos,Abilities,0,Acc,DMod,SMod,CT),
                   TempChar, MsgBuff),
        format(string(MsgDesc), "StressOut ausgelöst durch ~w: ~w", [AbilityName, Desc]),
        Msgs0 = [[MsgDesc, MsgBuff]]
    ),
    % 3) Genauigkeits‑Debuff von 2 anwenden
    DebuffPower is -2,
    apply_buff(accuracy, DebuffPower, TempChar, FinalChar, MsgAcc),
    % 4) Nachrichten zusammenstellen
    append(Msgs0, [[MsgAcc]], Messages).

is_buff_or_debuff(ability(_,_,_,_,_,Type,_,_)) :- member(Type, [buff, debuff]).

% Initialisierung des Kampfes
% init_phase entscheidet, wer zuerst am Zug ist
init_phase(Order) :-
    roll20(R1),
    roll20(R2),
    (R1 >= R2 -> Order = player ; Order = enemy), % Player gets tie-breaker
    format('Initiative: Dante (~w) vs Gegner (~w). ~w hat den ersten Zug.~n', [R1, R2, Order]),
    wait_for_input. % Pause after initiative roll

% Hauptkampf-Loop
% Basisfall: Spieler besiegt
fight_loop(_, char(_,HPu,_,_,_,_,_,_,_,_,_), _) :-
    HPu =< 0,
    writeln('Du bist jetzt auf 0 HP. Du hast leider Verloren!'),
    !, % Cut to prevent backtracking
    fail. % Signal loss

% Basisfall: Gegner besiegt
fight_loop(_, _, char(_,HPt,_,_,_,_,_,_,_,_,_)) :-
    HPt =< 0,
    writeln('Der Gegner ist besiegt!'),
    !, % Cut to prevent backtracking
    true. % Signal win

% Spieler-Zug
fight_loop(player, Player, Enemy) :-
    Player = char(_,_,_,_,_,_,StressU,_,_,_,_),
    ( StressU >= 100 -> % Stress-Out des Spielers
        stress_out_char(Player, NewPlayer, Msgs),
        print_messages(Msgs),
        wait_for_input,
        fight_loop(player, NewPlayer, Enemy)
    ; % Normaler Spieler-Zug
        display_status(Player),
        display_menu(Player),
        read_choice(Choice),
        handle_player_choice(Choice, Player, Enemy, IntermediatePlayer, IntermediateEnemy, EnemyTurnFlag),

        % Überprüfe sofort nach Spieleraktion, ob Gegner besiegt wurde
        ( IntermediateEnemy = char(_,HPt,_,_,_,_,_,_,_,_,_), HPt =< 0 ->
            writeln('Der Gegner ist besiegt!'), % <-- Füge diese Zeile hinzu
            true % Signalisiert den Sieg und beendet den Kampf
        ;
            % Gegner noch am Leben, gehe zum Zug des Gegners oder wiederhole Spielerzug
            ( EnemyTurnFlag -> % Gegner-Zug ist an der Reihe
                IntermediateEnemy = char(_,_,_,_,_,_,StressT1,_,_,_,_),
                ( StressT1 >= 100 -> % Stress-Out des Gegners
                    stress_out_char(IntermediateEnemy, NewEnemyAfterStress, Msgs2),
                    print_messages(Msgs2),
                    wait_for_input,
                    enemy_turn(NewEnemyAfterStress, IntermediatePlayer, NewPlayerAfterEnemyTurn),
                    wait_for_input,
                    fight_loop(player, NewPlayerAfterEnemyTurn, NewEnemyAfterStress)
                ; % Normaler Gegner-Zug
                    enemy_turn(IntermediateEnemy, IntermediatePlayer, NewPlayerAfterEnemyTurn),
                    wait_for_input,
                    fight_loop(player, NewPlayerAfterEnemyTurn, IntermediateEnemy)
                )
            ; % Spieler-Zug wiederholen (z.B. für Infos oder ungültige Eingabe)
                fight_loop(player, IntermediatePlayer, IntermediateEnemy)
            )
        )
    ).

% Gegner-Zug
fight_loop(enemy, Player, Enemy) :-
    Enemy = char(_,_,_,_,_,_,StressE,_,_,_,_),
    ( StressE >= 100 -> % Stress-Out des Gegners
        stress_out_char(Enemy, NewEnemy, Msgs),
        print_messages(Msgs),
        wait_for_input,
        fight_loop(enemy, Player, NewEnemy)
    ; % Normaler Gegner-Zug
        enemy_turn(Enemy, Player, NewPlayerAfterEnemyTurn),
        wait_for_input, % Pause nach den Aktionen des Gegners

        % Überprüfe sofort nach Gegneraktion, ob Spieler besiegt wurde
        ( NewPlayerAfterEnemyTurn = char(_,HPu,_,_,_,_,_,_,_,_,_), HPu =< 0 ->
            % Spieler besiegt, der Basisfall fight_loop/3 wird es beim nächsten Aufruf erkennen
            fail % Signalisiert sofortigen Kampfabbruch und Verlust
        ;
            % Spieler noch am Leben, wechsle zum Spieler-Zug
            fight_loop(player, NewPlayerAfterEnemyTurn, Enemy)
        )
    ).

% Startet den Kampf zwischen Spieler und Gegner
start_fight(Player, Enemy) :- % Erlaubt jetzt beliebige Feinde
    fight(Player, Enemy).

% Implementierung des Kampfes
fight(Player, Enemy) :-
    init_phase(Order),
    ( Order == player ->
        fight_loop(player, Player, Enemy)
    ;
        fight_loop(enemy, Player, Enemy)
    ).

% Hilfsprädikate für den Kampfausgang (obwohl fight_loop diese intern handhabt, gut zur Klarheit)
player_has_won(_, char(_,HPt,_,_,_,_,_,_,_,_,_)) :- HPt =< 0.
player_has_lost(char(_,HPu,_,_,_,_,_,_,_,_,_)) :- HPu =< 0.


handle_player_choice(Choice, Player, Enemy, NewPlayer, NewEnemy, EnemyTurnFlag) :-
    Player = char(_,_,_,_,_,Abilities,_,_,_,_,_),
    length(Abilities, L),
    InfoOption is L + 1,
    ( Choice == InfoOption ->
        print_spell_info(Abilities),
        NewPlayer = Player,
        NewEnemy = Enemy,
        EnemyTurnFlag = false % Spielerzug wiederholt sich
    ; integer(Choice), Choice >= 1, Choice =< L ->
        nth1(Choice, Abilities, ability(Name, _, _, _, _, TypeA, _, _)),
        ( (TypeA == heal ; TypeA == buff) ->
            use_ability(Player, Player, Name, NewPlayer, _, Msgs), % Spieler nutzt Fähigkeit auf sich selbst
            print_messages(Msgs),
            wait_for_input, % Pause nach Aktion des Spielers
            NewEnemy = Enemy % Ziel (Gegner) bleibt unverändert
        ; % Angriff oder Debuff
            use_ability(Player, Enemy, Name, NewPlayer, NewEnemy, Msgs), % Spieler nutzt Fähigkeit auf Gegner
            print_messages(Msgs),
            wait_for_input % Pause nach Aktion des Spielers
        ),
        EnemyTurnFlag = true % Gegner erhält einen Zug (wird im fight_loop weiter geprüft)
    ;
        writeln('Ungültige Auswahl.'),
        NewPlayer = Player,
        NewEnemy = Enemy,
        EnemyTurnFlag = false % Spielerzug wiederholt sich
    ).

enemy_turn(Enemy, Player, NewPlayer) :-
    Enemy = char(NameE,_,_,ACe,_,AbilitiesE,_,AccE,_,_,_),
    % Filtere Fähigkeiten, die der Gegner offensiv gegen den Spieler einsetzen kann
    include(can_enemy_use_against_player, AbilitiesE, UsableAbilities),
    ( UsableAbilities = [] ->
        format('~w kann keine Fähigkeit einsetzen.~n', [NameE]),
        NewPlayer = Player
    ;
        length(UsableAbilities, L),
        random_between(1, L, I),
        nth1(I, UsableAbilities, ability(NameA, Desc, _, MinP, MaxP, TypeA, StressEffect, BuffType)),
        format('~w erhebt sich und setzt ~w ein - ~w~n', [NameE, NameA, Desc]), nl,

        Player = char(NameP,HPp,MaxHPp,ACp,PosP,AbilitiesP,StressP,AccP,DModP,SModP,_),

        ( TypeA == attack ->
            roll20(Raw), AttackRoll is Raw + AccE,
            ( AttackRoll >= ACp ->
                random_between(MinP, MaxP, Power0), % Correctly use MinP/MaxP for the power roll
                Damage is Power0,
                NewHP is max(0, HPp - Damage),
                NewStress is StressP + StressEffect,
                format('Du erleidest ~w Schaden, Stress +~w~n', [Damage, StressEffect]),
                NewPlayer = char(NameP,NewHP,MaxHPp,ACp,PosP,AbilitiesP,NewStress,AccP,DModP,SModP,_)
            ;
                writeln('Gegner verfehlt.'),
                NewPlayer = Player
            )
        ; (TypeA == debuff ; TypeA == buff) ->
            random_between(MinP, MaxP, Power0), % Correctly use MinP/MaxP for the power roll
             ( TypeA == debuff ->
                 Power is -Power0
             ; Power is Power0
             ),
            apply_buff(BuffType, Power, Player, NewPlayer, _), % Discard message for enemy buffs/debuffs for now
            format('~w ist betroffen von ~w: ~w~n', [NameP, NameA, Desc])
        ;
            writeln('Wirkung nicht implementiert.'),
            NewPlayer = Player
        )
    ).

can_enemy_use_against_player(ability(_,_,_,_,_,attack,_,_)).
can_enemy_use_against_player(ability(_,_,_,_,_,debuff,_,_)).
can_enemy_use_against_player(ability(_,_,_,_,_,buff,_,_)). % Enemy can buff self, current logic applies to player, needs refinement if enemy buffs self

% --- Anzeige- und Hilfsprädikate ---

display_status(char(Name,HP,MaxHP,_,_,_,Stress,Acc,DMod,SMod,_)) :-
    format('[~w | HP: ~w/~w | Stress: ~w | Acc: ~w | DmgMod: ~w | StrMod: ~w]~n', [Name,HP,MaxHP,Stress,Acc,DMod,SMod]).

display_menu(char(_,_,_,_,_,Abilities,_,_,_,_,_)) :-
    writeln('Was willst du tun?'),
    forall(nth1(I, Abilities, ability(Name,_,_,_,_,_,_,_)), format('~w. ~w~n', [I, Name])),
    length(Abilities, L),
    Info is L + 1,
    format('~w. Fähigkeits-Informationen~n', [Info]).

read_choice(Choice) :-
    repeat,
    write('Deine Wahl: '),
    read_line_to_string(user_input, S),
    ( number_string(N,S) ->
        Choice = N
    ;
        Choice = -1, % Ungültiger Eingabetyp
        writeln('Ungültige Eingabe. Bitte gib eine Zahl ein.')
    ),
    ( (integer(Choice), Choice >= 1) ; Choice = -1 ), % Nur erfolgreich, wenn gültige Zahl oder -1
    !. % Cut, um Backtracking für repeat zu verhindern

print_spell_info([]).
print_spell_info([ability(Name,Desc,_,_,_,_,_,_)|T]) :-
    format('~w: ~w~n~n', [Name,Desc]),
    print_spell_info(T).

print_messages([]).
print_messages([List|T]) :- print_list(List), print_messages(T).
print_list([]).
print_list([M|T]) :- writeln(M), print_list(T).

% Warte auf Benutzereingabe, um fortzufahren
wait_for_input :-
    flush_output, % Sicherstellen, dass alle vorherigen Ausgaben sichtbar sind
    read_line_to_string(user_input, _).

% Utility zum Pausieren der Ausgabe alle 3 Zeilen
pause_print([]).
pause_print([Line1, Line2, Line3 | Rest]) :-
    writeln(Line1), writeln(Line2), writeln(Line3),
    wait_for_input,
    pause_print(Rest).
pause_print([Line1, Line2]) :-
    writeln(Line1), writeln(Line2).
pause_print([Line1]) :-
    writeln(Line1).

% --- Kapitel und Story-Prädikate ---

% Startpunkt des Spiels
start :-
    retractall(player_state(_)), % Alte Spielerdaten löschen
    retractall(player_has_helmet), % Helm-Status zurücksetzen
    retractall(muse_state(_)), % Musen-Status zurücksetzen
    setup_player_initial, % Spielerinitialisierung am Anfang
    chapter1_alchemist_intro. % Start der Geschichte

% Initialisiert den Spieler nur einmal am Start
setup_player_initial :-
    AbilitiesP = [
        ability('Vera Spada', 'Ein schneller Hieb mit einer geweihten Klinge. (Moderater Schaden)', [1,2], 11, 18, attack, 0, none),
        % Gewissenserweckung ist jetzt ein Stress-Debuff
        ability('Gewissenserweckung', 'Dante zwingt den Gegner, sich seiner Schuld zu stellen und stark zu stressen.', [1,2], 20,30, debuff, 0, stress),
        ability('Gebet der Klarheit', 'Ein ruhiges Gebet stärkt Dantes Geist. (leichte Heilung)', [1,2], 4, 11, heal, 0, hp),
        ability('Klarer Blick', 'Dante schließt kurz die Augen, richtet seinen Geist - und öffnet sie mit tödlicher Entschlossenheit. (Erhöht die Genauigkeit)', [1,2], 1, 2, buff, 0, accuracy)
    ],
    assertz(player_state(char('Dante', 100, 100, 11, 1, AbilitiesP, 0, 3, 0, 0, player))).

% --- Kapitel 1: Der Ruf in die Tiefe ---
chapter1_alchemist_intro :-
    nl,
    write('Kapitel 1: Der Ruf in die Tiefe'), nl,
    write('-------------------------------'), nl, nl,
    Lines = [
        '"Ein wenig hiervon... und noch ein Hauch davon..." – BOOM!',
        'Eine kleine Explosion hüllt das Gefäß in Rauch.',
        '„Was tust du denn schon wieder, Dante?“ fragt dein Vater entsetzt und blickt auf das qualmende Glas.',
        '„Ach, nichts...“ murmelst du und wischst dir Ruß von der Stirn. „Ich bringe es einfach nicht zu Ende.“',
        '„Denkst du nicht, dass es nur eine alte Legende ist, mein Sohn?“ fragt dein Vater, während er sich mit müder Geste an die Schläfen fasst.',
        '„Nein! Es muss möglich sein. Ich war so nah dran! Mir fehlt nur noch ein letzter Bestandteil... aber was könnte es nur sein?“',
        'Deine Mutter tritt neugierig ins Zimmer.',
        '„Bist du immer noch mit deiner Alchemie beschäftigt?“',
        '„Ja. Ich bin kurz davor, ich spüre es!“ antwortest du mit leuchtenden Augen.',
        '„Na schön – dann lassen wir dich in Ruhe. Aber komm nicht zu spät zum Schwertkampf!“',
        '„Ja, ich brauche nicht mehr lange!“',
        'Die Tür schließt sich hinter ihnen. Dann hörst du leises Flüstern.',
        '„Seit Beatrices Tod ist er ganz in seine Alchimisten-Träume versunken... Ich will nicht, dass er das Schwert aus der Hand legt – schließlich soll er bald zum Ritter geschlagen werden,“ murmelt der Vater.',
        '„Er wird schon seinen Weg finden. Er ist ein kluger Junge,“ antwortet die Mutter leise.',
        '„Sie wissen doch gar nicht, wie es ist, jemanden zu verlieren…“ murmelst du, während du auf das halb verkohlte Rezept blickst. Ein letztes Mal versuchst du, die geheimen Anweisungen umzudeuten, das Verhältnis der Zutaten zu ändern – vielleicht ist es der Atem der Nachtkerze? Oder ein Tropfen Tränenkraut? Es ist ein Trank, wie ihn nur wenige wagen zu denken – eine Essenz, von der alte Schriften raunen, dass sie einem den Weg in die Tiefe der neun Kreise der Hölle öffnet.',
        'Die Legende, so heißt es, stammt von alten Druiden, die einst in verborgenen Hainen mit den Schatten jenseits der Welt sprachen. Dort sei der Schleier zwischen Leben und Tod dünner, und man könne in die dunklen Gefilde hinabsteigen, wenn das Gleichgewicht der Elemente gewahrt sei.',
        '„ES KLAPPT!“ rufst du mit plötzlicher Begeisterung.',
        '„Es sieht genau so aus wie im Buch beschrieben…“',
        'Voller Erwartung – und Sehnsucht nach Beatrice – führst du das Glas an deine Lippen und trinkst die Hälfte des Trankes.',
        'Zuerst wird dir mulmig, dann schwindlig. Deine Sicht verschwimmt.',
        'Und dann – platsch.',
        'Du fällst zu Boden.'
    ],
    pause_print(Lines),
    chapter1_virgil_encounter.

chapter1_virgil_encounter :-
    Lines = [
        'Du kommst langsam wieder zu dir.',
        '„Aah… mein Kopf…“ murmelst du benommen.',
        'Langsam öffnest du die Augen. Um dich herum nur dichter Wald – uralte Bäume mit verdrehten Ästen, deren Rinde wie verbrannt wirkt. Der Himmel ist finster, durchzogen von rötlichen Schlieren, als hätte sich ein Fluch über diese Welt gelegt.',
        'Plötzlich hörst du eine Stimme hinter dir.',
        '„Hallo, Dante.“',
        'Mit einem Ruck fährst du herum. Panik liegt in deinem Blick.',
        'Ein fremder Schatten steht zwischen zwei Bäumen.',
        '„Ich sehe, du bist erwacht.“'
    ],
    pause_print(Lines),
    writeln('Was willst du fragen?'),
    writeln('1. "Wer bist du?"'),
    writeln('2. "Wo bin ich hier?"'),
    read_choice(Choice),
    ( Choice == 1 -> chapter1_virgil_who
    ; Choice == 2 -> chapter1_virgil_where
    ; writeln('Ungültige Wahl. Bitte wähle 1 oder 2.'), chapter1_virgil_encounter
    ).

chapter1_virgil_who :-
    Lines = [
        'Du machst einen Schritt zurück, deine Stimme zittert.',
        '„Wer… wer bist du?“',
        'Der Mann neigt leicht den Kopf, seine Stimme ist ruhig, fast würdevoll.',
        '„Ein Freund, wenn du es zulässt. Ein Führer, wenn du bereit bist.“',
        'Er tritt langsam aus dem Schatten der Bäume. Der Umhang, den er trägt, wirkt alt, wie aus einer anderen Zeit, und sein Blick ist ruhig, aber durchdringend.',
        '„Man nennt mich Virgil.“',
        'Du stockst. Der Name kommt dir bekannt vor – aus alten Texten, Legenden vielleicht?',
        '„Du… Virgil? Der Dichter?“',
        'Er nickt leicht.',
        '„Ich war es einst. Nun bin ich mehr... und zugleich weniger.“',
        'Ein Windhauch zieht durch die verdorben wirkenden Äste, Blätter rascheln wie Flüstern.',
        '„Du bist gefallen, Dante. Gefallen in eine Welt jenseits deiner. Doch es ist kein Zufall, dass du hier bist.“',
        'Er tritt näher und seine Stimme wird ernster:',
        '„Wenn du Beatrice wirklich retten willst, wirst du weitergehen müssen. Doch allein wirst du keinen Schritt weit kommen.“',
        'Du spürst Gänsehaut am ganzen Körper.'
    ],
    pause_print(Lines),
    chapter1_crossroads.

chapter1_virgil_where :-
    Lines = [
        '„Wo bin ich hier?“ fragst du benommen, während du dich langsam aufrichtest.',
        'Die Luft ist schwer, die Bäume verdreht und schwarz, der Himmel von einem düsteren Rot durchzogen.',
        'Die Gestalt vor dir antwortet mit tiefer, ruhiger Stimme:',
        '„Du befindest dich an einem Ort, den selbst die Tapfersten meiden. Dies ist das Vorzimmer des Bösen – der nullte Kreis. Von hier aus führen die Wege hinab in die neun Kreise der Hölle.“',
        'Ein Schauer läuft dir über den Rücken.',
        'Du blickst ihn genauer an. Etwas an ihm kommt dir seltsam vertraut vor.',
        '„Ich... ich kenne dich doch. Du bist... dieser Dichter... wie war dein Name noch gleich?“',
        'Er senkt leicht den Kopf.',
        '„Virgil ist mein Name.“',
        'Du erstarrst kurz.',
        '„Ja, genau! Virgil... Was machst du hier unten?“',
        'Sein Blick wird ernst.',
        '„Das ist ohne Bedeutung. Was zählt, ist, dass ich weiß, warum du hier bist.“',
        'Er tritt näher, seine Stimme wird klar und eindringlich:',
        '„Wenn du Beatrice wirklich retten willst, musst du weitergehen. Aber allein wirst du keinen Schritt weit kommen.“',
        'Ein eisiger Hauch streicht durch die Bäume. Dir läuft Gänsehaut über den Körper.'
    ],
    pause_print(Lines),
    chapter1_crossroads.

chapter1_crossroads :-
    Lines = [
        'Du blickst dich langsam um, während der Nebel zwischen den Bäumen tanzt.',
        'Im Norden erkennst du vage die Umrisse eines Gebäudes – halb verborgen im Dunst, wie ein Schatten der Vergangenheit. Ist es eine alte Ruine? Vielleicht findest du dort etwas Nützliches... Doch aus derselben Richtung hallen verzerrte Schreie durch die Luft – gequält und fern, und doch beunruhigend nah.',
        'Im Osten führt ein schmaler Pfad weiter. Der Boden wirkt dort fester, und zwischen den krummen Bäumen liegt der Weg in bedrückender Stille.',
        'Virgil hebt langsam die Hand und deutet auf diesen Pfad, ohne ein Wort zu sagen – doch seine Geste ist eindeutig.',
        'Im Süden breitet sich ein düsteres Sumpfgebiet aus. Schwarzes Wasser glitzert zwischen faulen Bäumen, und der Gestank von Verwesung liegt in der Luft.',
        'Der Wind schweigt. Alles schweigt.'
    ],
    pause_print(Lines),
    writeln('Wohin gehst du?'),
    writeln('1. Zum Gebäude im Norden – trotz der Schreie'),
    writeln('2. Dem Pfad im Osten folgen, Virgils Zeichen vertrauen'),
    writeln('3. In das Sumpfgebiet im Süden wagen'),
    read_choice(Choice),
    ( Choice == 1 -> chapter1_north_path
    ; Choice == 2 -> chapter1_east_path
    ; Choice == 3 -> chapter1_south_path
    ; writeln('Ungültige Wahl. Bitte wähle 1, 2 oder 3.'), chapter1_crossroads
    ).

chapter1_north_path :-
    Lines = [
        'Du entscheidest dich, in Richtung Norden aufzubrechen.',
        'Der Weg dorthin ist still, nur das Knacken deiner Schritte auf dem toten Laub begleitet dich. Als du näher kommst, bestätigt sich dein Verdacht – vor dir erhebt sich eine alte, verfallene Ruine. Die Mauern sind vom Zahn der Zeit gezeichnet, mit tiefen Rissen und überwachsenen Steinen.',
        'Trotz der düsteren Stimmung spürst du einen Hauch von Neugier – vielleicht verbirgt sich hier etwas Nützliches?',
        'Mit Bedacht trittst du ein. Das Innere ist leer und still, fast gespenstisch. Räume brechen an vielen Stellen ein, Wände sind von feuchtem Moos und seltsam leblosen Pflanzen überwuchert. Doch dann entdeckst du zwischen den Ranken etwas Metallisches.',
        'Ein alter, aber erstaunlich gut erhaltener Helm liegt halb verborgen im Grün. Du hebst ihn auf – er ist schwer, robust, und könnte dir durchaus nützen.',
        ' (+1 Defense)',
        'Du setzt ihn auf und fühlst dich ein wenig sicherer.'
    ],
    pause_print(Lines),
    assertz(player_has_helmet), % Helm wurde gefunden und aufgesetzt
    player_state(char(N,HP,MaxHP,AC,Pos,Abs,Str,Acc,DMod,SMod,CT)),
    NewAC is AC + 1, % Erhöht die Rüstungsklasse
    retract(player_state(_)),
    assertz(player_state(char(N,HP,MaxHP,NewAC,Pos,Abs,Str,Acc,DMod,SMod,CT))),
    writeln('Deine Rüstungsklasse wurde um 1 erhöht.'),
    Lines2 = [
        'Mit einem letzten Blick in die verlassene Halle kehrst du zurück – der Weg zu Virgil scheint nun klarer als zuvor.'
    ],
    pause_print(Lines2),
    chapter1_proceed_to_east_path. % Leitet zur Standard-Story-Fortsetzung über

chapter1_south_path :-
    Lines = [
        'Du begibst dich mit der leisen Hoffnung, im Süden vielleicht etwas Verwertbares zu finden, in Richtung des düsteren Sumpfgebiets.',
        'Der Boden wird weicher, bald schon schlammig. Deine Schritte sinken ein, und mit jedem Meter breitet sich ein schwerer Gestank aus – nach Teer, Moder und altem Blut.',
        'Doch plötzlich... Stimmen. Flüsternd, drohend, überall um dich herum.',
        '„Was ist das…?“ flüsterst du dir selbst zu, während dein Blick suchend durch den Nebel gleitet.',
        'Dann siehst du sie: Aus dem Morast erheben sich Gestalten – halb verwest, mit leeren Blicken und schleppenden Bewegungen. Ihre Augen flackern träge, als wäre jeder Funke Leben aus ihnen gewichen.',
        'Kreaturen der Hoffnungslosigkeit.',
        'Mit jedem Schritt, den sie auf dich zugehen, spürst du, wie sich Kälte in deinem Herzen ausbreitet.'
    ],
    pause_print(Lines),
    writeln('= Es kommt zum Kampf gegen die Hoffnungslosen ='),
    player_state(Player),
    Enemy = char('Kreatur der Hoffnungslosigkeit', 60, 60, 10, 1,
        [
            ability('Modernder Griff', 'Ein kalter Griff, der dir Lebensenergie entzieht. (Moderater Schaden)', [1,2], 8, 15, attack, 10, none),
            ability('Atem der Verzweiflung', 'Ein Nebel des Zweifels umhüllt dich. (Geringer Schaden, hoher Stress)', [1,2], 3, 7, attack, 25, none)
        ], 0, 0, 0, 0, enemy),
    ( start_fight(Player, Enemy) ->
        Lines2 = [
            'Mit letzter Kraft stößt du dein Schwert in die Brust des letzten Wesens. Es stößt ein leises Gurgeln aus, bevor es leblos in den Sumpf zurücksinkt.',
            'Du atmest schwer, blickst dich hastig um – aber es scheint still geworden zu sein. Ohne zu zögern rennst du zurück, zurück zu Virgil.',
            'Dein Herz hämmert, und du hoffst, nie wieder so etwas sehen zu müssen.'
        ],
        pause_print(Lines2),
        chapter1_proceed_to_east_path % Leitet zur Standard-Story-Fortsetzung über
    ;
        Lines2 = [
            'Du schlägst um dich, wehrst Angriff um Angriff ab. Doch es sind zu viele.',
            'Plötzlich spürst du einen Griff an deinem Rücken – einer der Kreaturen hält dich fest. Ein zweiter schnappt zu.',
            'Ein beißender Schmerz durchfährt deine Kehle. Warmes Blut rinnt an deinem Hals herab, und deine Kräfte schwinden.',
            'Du fällst zu Boden.',
            'Der Himmel verdunkelt sich.',
            'Und so endet deine Reise hier – in Hoffnungslosigkeit.'
        ],
        pause_print(Lines2),
        fail % Game Over
    ).

chapter1_east_path :-
    Lines = [
        'Du begibst dich gemeinsam mit Virgil auf den Weg nach Osten.',
        'Der schmale Pfad windet sich durch kahle Bäume, deren Äste wie knochige Finger in den düsteren Himmel ragen. Zwischen den Sträuchern leuchten seltsame Beeren – in Farben, die du nie zuvor gesehen hast. Du gehst vorsichtig, fast schon paranoid, mit jedem Rascheln in der Dunkelheit rechnend.',
        'Die Reise zieht sich endlos, als würde die Zeit selbst hier nicht weiterfließen.',
        'Dann endlich – eine Lichtung. Vor euch: eine große Menschenmenge.',
        'Menschliche Gestalten, stumm, blass, in sich zusammengesunken. Ihre Augen leer, ihre Körper kaum mehr als Schatten ihres einstigen Selbst.',
        'Sie warten.',
        '„Die Nächsten, bitte!"',
        'Eine schneidende Stimme ruft über den Platz.',
        '„Das ist Charon“, flüstert Virgil dir zu. „Der Fährmann. Er bringt die Seelen über den Fluss Acheron – von der Vorhölle zu Minos, dem Richter. Wir sollten uns beeilen und an Bord gehen.“',
        'Ohne groß zu überlegen rufst du: „Hey! Ich möchte mitfahren!“',
        'Wie auf ein unsichtbares Kommando teilt sich die wartende Menge.',
        'Ein schmaler Pfad öffnet sich direkt zur Fähre.',
        'Verwirrt blickst du zu Virgil. „Warum machen die uns Platz?“',
        'Er sieht dich ernst an. „Glaubst du wirklich, jemand zieht das Leid eines der Kreise dem Warten auf sein Urteil vor?“',
        'Du schluckst.',
        'Dann setzt du langsam einen Fuß vor den anderen und gehst auf die Fähre zu – bereit, dich dem zu stellen, was jenseits des Flusses liegt.'
    ],
    pause_print(Lines),
    start_chapter2_intro. % Leitet direkt zu Kapitel 2 über

chapter1_proceed_to_east_path :-
    % This predicate acts as a merge point for North and South paths
    % to lead to the same continuation as the East path.
    % The story text implies returning to Virgil then proceeding.
    Lines = [
        'Du stehst wieder bei Virgil. Der Weg nach Osten ist nun der einzige Weg, der sinnvoll erscheint.'
    ],
    pause_print(Lines),
    chapter1_east_path. % Springt zum Ost-Pfad

% --- Kapitel 2: Urteil ---
start_chapter2_intro :-
    nl,
    write('Kapitel 2: Urteil'), nl,
    write('-----------------'), nl, nl,
    Lines = [
        'Das Wasser liegt still da – unnatürlich still. Kein Windhauch kräuselt die Oberfläche, kein Laut durchbricht die gespenstische Stille.',
        'Du hast noch nie zuvor eine Überfahrt erlebt, die so still, so bedrückend war.',
        'Kaum zwanzig Minuten vergehen, da erreicht ihr bereits das andere Ufer.',
        'Langsam steigst du aus dem Boot und betrittst einen morsch wirkenden Holzsteg. Jeder Schritt knarrt unter deinem Gewicht, als würde das Holz selbst vor dem fürchten, was vor dir liegt.',
        'Dein Herz schlägt schneller. Deine Hände zittern leicht.',
        'Vor dir erhebt sich ein dunkler Durchgang – der Eingang zur Halle des großen Richters: Minos – derjenige, der über die Verdammten urteilt und sie den Kreisen zuweist, die ihrem innersten Wesen entsprechen.',
        'Du stehst nun an der Schwelle.',
        'Bist du bereit, dich seinem Urteil zu stellen?'
    ],
    pause_print(Lines),
    writeln('1. Ja'),
    writeln('2. Nein'),
    read_choice(Choice),
    ( Choice == 1 -> chapter2_minos_approach_courage
    ; Choice == 2 -> chapter2_minos_approach_hesitation
    ; writeln('Ungültige Wahl. Bitte wähle 1 oder 2.'), start_chapter2_intro
    ).

chapter2_minos_approach_courage :-
    Lines = [
        'Mit fester Miene und dem Anschein von Selbstbewusstsein schreitest du durch die Tore zum Urteilssaal von Minos.',
        'Dunkelheit empfängt dich – dicht und undurchdringlich –, doch du bleibst standhaft.'
    ],
    pause_print(Lines),
    chapter2_minos_approach_common_part.

chapter2_minos_approach_hesitation :-
    Lines = [
        'Der Wind steht still, doch in dir tobt ein Sturm.',
        'Dein Blick schweift suchend über das dunkle Gemäuer, während dein Herz rast.',
        '„Was, wenn ich dort drinnen sterbe? Was, wenn alles hier endet?“',
        'Du spürst, wie sich Kälte in deinem Inneren ausbreitet.',
        '„Dann verliere ich nicht nur Beatrice… sondern auch alles andere. Meine Familie. Meine Zukunft. Mich selbst.“',
        'Für einen Moment zögerst du. Doch dann ballst du deine Faust.',
        '„Nein. So darf es nicht enden.“',
        'Ein letzter Gedanke, der sich wie eine Klinge durch den Nebel deiner Angst schneidet.',
        'Du nimmst deinen ganzen Mut auf und schreitest durch die Tore zum Urteilssaal von Minos.'
    ],
    pause_print(Lines),
    chapter2_minos_approach_common_part.

chapter2_minos_approach_common_part :-
    Lines = [
        'Am Eingang entdeckst du eine alte, verstaubte Fackel, die in einer Wandhalterung steckt.',
        'Mit einer schnellen, beinahe nervösen Geste zündest du sie an.',
        'Das zitternde Licht offenbart das Innere des Korridors: kalt, verlassen, leblos.',
        '„Warum sollte hier überhaupt jemand etwas gestalten?“ denkst du dir.',
        'Die Wände sind roh, von Zeit und Leid gezeichnet, überwuchert von totem Pflanzenwerk.',
        'Die Schatten tanzen an den Wänden, einzig von deiner Fackel zum Leben erweckt.',
        'Mit jedem Schritt, den du näher an den Saal des Richters trittst, wächst das Gewicht auf deinen Schultern.',
        'Deine Nervosität kriecht langsam in deine Glieder.',
        'Eine alte Steintreppe führt dich hinauf. Jeder Tritt hallt bedrohlich wider.',
        'Virgil bleibt zurück, sein Blick ruht auf dir.',
        '„Ich glaube an dich“, sagt er leise – und seine Stimme klingt, als käme sie aus weiter Ferne.',
        'Dann stehst du vor der Tür.',
        'Du atmest tief ein und trittst ein.',
        'Ein Wispern aus der Dunkelheit. Dann eine Stimme – tief und rau:',
        '„Dante. Ich habe dich bereits erwartet.“',
        'Du spannst deine Schultern an.',
        '„Du kannst mir gar nichts!“ rufst du, die Fackel fest in der Hand.',
        'Aus der Dunkelheit schält sich langsam eine massive Gestalt – Minos.',
        'Mit jedem Schritt, den er auf dich zumacht, spürst du die Luft um dich schwerer werden.',
        'Seine Augen sind leer und doch durchdringend, als würden sie deine tiefsten Ängste lesen.',
        'Um seinen Körper winden sich lebendige Schlangen – träge, aber wachsam –, als wären sie seine Kinder, seine Gedanken, seine Strafe.',
        'Nun steht er vor dir.',
        'Ein Wesen voller uraltem Zorn.',
        'Ein Richter mit einer Macht, die du dir kaum ausmalen kannst.'
    ],
    pause_print(Lines),
    writeln('= Der Kampf gegen Minos geht los ='),
    chapter2_start_minos_fight.

chapter2_start_minos_fight :-
    player_state(Player), % Hole den aktuellen Spielerstatus
    AbilitiesM = [
        ability('Richterspruch', 'Minos zeigt mit seiner Klauenhand auf einen Gegner - ein unsichtbares Gewicht lastet auf ihm. (Hoher Schaden)', [1,2], 15, 25, attack, 0, none),
        ability('Zungenurteil', 'Aus seinem Maul fährt eine peitschende, schwarze Zunge. (Stress + wenig Schaden)', [1,2], 4,7, attack, 11, none),
        ability('Richthammer', 'Minos schwingt mit seinem Richterhammer. (Moderater Schaden)', [1,2], 8, 11, attack, 0, none),
        ability('Nervenzerfetzender Blick', 'Minos sieht dich an und raubt dir die Konzentration. (Stress + Accuracy Debuff)', [1,2], 1, 3, debuff, 0, accuracy)
    ],
    Minos = char('Minos', 200, 200, 13, 1, AbilitiesM, 0, 0, 0, 0, boss),

    ( start_fight(Player, Minos) ->
        minos_defeated
    ;
        writeln('Du wurdest von Minos überwältigt. Dein Urteil ist gefällt... Game Over.'),
        fail % Game Over
    ).

% Story continuation after Minos fight
minos_defeated :- % This predicate is called upon winning the fight against Minos
    Lines = [
        'Minos ist gefallen. Kaum berührt sein lebloser Körper den Boden, beginnt die Erde unter deinen Füßen zu beben.',
        'Erst ein Zittern, dann ein Dröhnen – so heftig, dass die Mauern des uralten Gemäuers zu ächzen beginnen.',
        'Risse durchziehen den Boden wie dunkle Adern, Steine lösen sich aus den Wänden und stürzen scheppernd in die Tiefe.',
        'Du spürst, wie Panik in dir aufkeimt.',
        '„Das ganze Anwesen… es stürzt ein!“',
        'Staub wirbelt auf, du hustest, dein Blick irrt umher. Du brauchst einen Ausweg – jetzt.'
    ],
    pause_print(Lines),
    writeln('Was tust du?'),
    writeln('1. Versteck dich in einem aus Stein gebauten leeren Sarg.'),
    writeln('2. Renn auf die Tür hinter Minos zu.'),
    read_choice(Choice),
    ( Choice == 1 -> escape_sarg
    ; Choice == 2 -> escape_tuer
    ; writeln('Ungültige Wahl. Bitte wähle 1 oder 2.'), minos_defeated
    ).

escape_sarg :-
    Lines = [
        'Du rennst, so schnell du kannst, vorbei an zerbröckelnden Säulen und stürzenden Steinen – direkt auf den steinernen Sarg zu.',
        'Ohne zu zögern wirfst du den Deckel auf, wirfst dich hinein und ziehst ihn mit zitternden Händen zu.',
        'Finsternis umhüllt dich. Nur dein Atem bleibt – flach, hektisch, begleitet vom Beben des einstürzenden Anwesens über dir.',
        'Dann beginnt der Boden unter dir zu vibrieren. Ein feines Knacken – dann ein Riss, der sich durch das Gestein zieht.',
        'Plötzlich fühlst du es: Der Sarg fällt.',
        'Du wirst mitgerissen in die Tiefe.',
        'Du spürst den Wind an deinem Körper, der Druck der Tiefe, die dich verschlingt.',
        'Felsen rauschen an dir vorbei, doch der Sarg schützt dich wie ein letzter Schild.',
        'Mit einem dumpfen, fast sanften Aufprall endet der Sturz.',
        'Stille.',
        'Der Deckel kippt zur Seite.',
        'Du richtest dich auf – benommen, aber unverletzt.',
        'Als du dich umsiehst, erkennst du es sofort:',
        'Dies ist nicht mehr das zerfallene Gemäuer von Minos. Der Himmel ist grau und ruhelos, die Luft schwer von Bedeutung.',
        'Du bist weiter unten. Viel weiter.',
        'Der nächste Kreis.',
        'Ein flaches, weites Land liegt vor dir. Nebel kriecht über den Boden.',
        'In der Ferne erkennst du Silhouetten – viele, stumm, bleich, langsam wandelnd.',
        'Virgil steht einige Schritte entfernt und blickt dich ruhig an.',
        '„Willkommen im zweiten Kreis. Lust..“'
    ],
    pause_print(Lines),
    start_chapter3_intro.

escape_tuer :-
    Lines = [
        'Du stürzt los – dein Blick fixiert die Tür hinter Minos’ lebloser Gestalt.',
        'Da muss doch ein Ausgang sein, hoffst du fieberhaft.',
        'Du erreichst die Tür, wirfst dich dagegen, rüttelst mit aller Kraft daran – aber sie bleibt verschlossen. Kein Spalt, kein Nachgeben.',
        'Mit zitternden Fingern tastest du die Wände ab, suchst panisch nach einem anderen Ausweg. Doch es ist zu spät.',
        'Ein tiefes Grollen durchdringt den Boden – dann bricht er unter dir ein.',
        'Du fällst. Schwerelos. Zeitlos.',
        'Keine vier Sekunden – und doch scheint es eine Ewigkeit zu sein.',
        'Mit einem dumpfen Aufprall triffst du auf festen Untergrund.',
        'Du lebst.',
        'Atem flackert durch deine Lungen. Dein ganzer Körper schmerzt, als würdest du innerlich zerschlagen – aber du kannst dich bewegen.',
        '(Du erleidest 5 Schaden.)'
    ],
    pause_print(Lines),
    update_player_hp(-5), % Fügt 5 Schaden hinzu
    Lines2 = [
        'Langsam richtest du dich auf und blickst dich um.',
        'Dies ist nicht mehr Minos’ Gemäuer.',
        'Der Himmel ist bleiern und bewegt sich kaum – grau, schwer und von gespenstischer Ruhe.',
        'Du bist tiefer gefallen. Viel tiefer.',
        'Ein weites, flaches Land liegt vor dir, überzogen von fahlem Nebel, der sich über den Boden schleicht wie verlorene Gedanken.',
        'In der Ferne erkennst du schemenhafte Gestalten – bleich, langsam, schweigend.',
        'Ein vertrauter Schatten tritt aus dem Dunst.',
        'Virgil.',
        'Er blickt dich mit ruhigem Ernst an.',
        '„Willkommen im zweiten Kreis. Lust.“'
    ],
    pause_print(Lines2),
    start_chapter3_intro.

% --- Kapitel 3: Lust ---
start_chapter3_intro :-
    nl,
    write('Kapitel 3: Lust'), nl,
    write('-----------------'), nl, nl,
    Lines = [
        'Ein kalter Wind zieht auf – plötzlich und voller Verlangen. Er trägt kein Leben in sich, nur flüsternde Stimmen, verhallte Seufzer, gebrochene Schwüre.',
        'Du folgst Virgil durch die dichten Nebel, bis sich das graue Land langsam verändert. Die Ebene weicht steinernen Mauern, zerfetzen Tüchern, zerbrochenen Statuen von Liebenden in ewiger Umarmung – oder Trennung. Der Boden ist unruhig, als würde er atmen. Oder beben.',
        'Und dann hörst du es: das Heulen.',
        'Nicht tierisch. Menschlich. Roh. Lust, Schmerz und Verzweifnung in einem einzigen Laut, der aus allen Richtungen kommt. Über dir wirbelt der Wind stärker – und du erkennst Gestalten, die durch die Luft geschleudert werden, von einem Sturm, der niemals endet. Liebende, verdammt, für ihre Begierden für alle Zeit voneinander getrennt zu sein.',
        'Virgil bleibt stehen.',
        '„Dies ist der Ort derer, die sich der Leidenschaft mehr hingaben als der Vernunft. Der Sturm reißt sie auseinander, wie einst ihr Begehren sie verband.“',
        'Du schluckst schwer. Der Wind zerrt bereits an deinem Mantel.',
        'Dies ist kein Ort für Zweifel – und doch flüstert etwas in deinem Inneren: Was wärst du bereit zu tun… um Beatrice wieder in deinen Armen zu halten?'
    ],
    pause_print(Lines),
    writeln('Was willst du tun?'),
    writeln('1. „Ich folge dem Pfad in die Tiefe.“'),
    writeln('2. „Ich gehe nicht weiter. Ich suche einen anderen Weg.“'),
    read_choice(Choice),
    ( Choice == 1 -> chapter3_path_stege
    ; Choice == 2 -> chapter3_path_alternative
    ; writeln('Ungültige Wahl. Bitte wähle 1 oder 2.'), start_chapter3_intro
    ).

chapter3_path_stege :-
    Lines = [
        'Du trittst weiter. Der Wind weht wie das Flüstern ungezählter Lippen über die Ebene, der Nebel kriecht wie atmende Haut um deine Beine. Virgil bleibt hinter dir, seine Silhouette verschmilzt mit dem Grau.',
        'Vor dir liegt ein schmaler Steg aus morschem Holz, der sich in eine dunkle Schlucht zieht. Jeder Schritt hallt durch die Leere. Der Sturm wird stärker – warm, fast lebendig, wie ein Atem. Du hörst kein Brüllen, sondern Seufzer… Lust… Qual.',
        'Du zögerst. Etwas an diesem Wind schreckt dich ab. Ein Teil von dir will zurück – doch du zwingst dich, weiterzugehen.',
        'Da – eine Gestalt schlägt wie vom Himmel gefallen auf den Steg. Weiblich. Nackt. Blass. Ihre Augen durchbohren dich mit tiefer Sehnsucht, die an deine eigenen Gedanken rührt.',
        'Ein Schattenwesen. Die Verlorene Versuchung.'
    ],
    pause_print(Lines),
    writeln('Sie spricht nicht. Doch du fühlst, was sie will.'),
    writeln('= Kampf gegen die Verlorene Versuchung ='),
    player_state(Player),
    Enemy = char('Verlorene Versuchung', 80, 80, 11, 1,
        [
            ability('Verlockender Blick', 'Ein Blick, der deine Entschlossenheit schwächt. (Geringer Schaden, Stress)', [1,2], 5, 10, attack, 15, none),
            ability('Kuss der Sehnsucht', 'Ein Hauch, der dich nach dem Vergangenen sehnen lässt. (Debuff: Genauigkeit)', [1,2], 0, 0, debuff, 0, accuracy)
        ], 0, 0, 0, 0, enemy),
    ( start_fight(Player, Enemy) ->
        Lines2 = [
            'Du gehst weiter. Doch dann, als du fast das Plateau erreichst, stürzt ein Felsbrocken vor dir herab – der Weg ist blockiert.',
            'Verflucht.',
            'Du wendest dich zurück und entdeckst am Rand der Klippe etwas, das du vorher nicht bemerkt hast: eine fast überwucherte Felsöffnung, verborgen unter totem Efeu und versandeten Statuen. Dahinter – ein schmaler, kaum begehbarer Pfad, der sich in den Fels schraubt.',
            'Mit pochendem Herzen folgst du ihm. Die Luft verändert sich. Warm. Schwer. Duftend. Die Stimmen verstummen. Stattdessen Stille – und eine Präsenz.',
            'In einer natürlichen Grotte, halb aus Fels, halb aus uraltem Marmor gehauen, sitzt eine gefesselte Frau auf einem Thron. Ihre Ketten bestehen aus Licht und Schmerz zugleich. Die Wände erzählen Geschichten in verblassten Fresken – Götter, Begierde, verbotene Liebe.'
        ],
        pause_print(Lines2),
        chapter3_muse_encounter
    ;
        writeln('Du wurdest von der Verlorenen Versuchung in den Wahnsinn getrieben. Dein Abenteuer endet hier...'),
        fail % Game Over
    ).

chapter3_path_alternative :-
    Lines = [
        'Der Sturm ist zu stark. Etwas daran schreckt dich ab – nicht nur körperlich. Es liegt ein Bann auf diesem Wind, der mehr mit sich trägt als nur Staub.',
        'Du beginnst, den Klippenrand abzusuchen. Und tatsächlich – verborgen unter Efeu und zerfallenen Statuen findest du einen engen Pfad, der sich an der Felswand entlangwindet.',
        'Du folgst ihm, tief in eine Felsspalte hinein. Die Luft wird stickig, warm – der Sturm ist nicht mehr zu hören.',
        'Im Inneren: eine alte Grotte. An den Wänden hängen verblasste Fresken von Göttern der Liebe und Lust.',
        'In der Mitte der Höhle sitzt eine Gestalt auf einem steinernen Thron – in Ketten, die aus Licht bestehen.'
    ],
    pause_print(Lines),
    chapter3_muse_encounter.

chapter3_muse_encounter :-
    retractall(muse_state(_)), % Sicherstellen, dass der Muse-Zustand zurückgesetzt ist
    Lines = [
        'NPC – Die Gebundene Muse:',
        'Einst eine Inspirationsquelle für Dichter, nun verflucht, weil sie den Menschen zu viel Lust und Begehren offenbarte.'
    ],
    pause_print(Lines),
    writeln('Was willst du tun?'),
    writeln('1. Mit ihr sprechen – sie kennt den Pfad durch den Kreis, verlangt aber eine Gegenleistung.'),
    writeln('2. Sie befreien – was Risiken birgt.'),
    writeln('3. Sie zurücklassen – und vielleicht den Zorn des Kreises auf dich ziehen.'),
    read_choice(Choice),
    ( Choice == 1 -> chapter3_muse_speak
    ; Choice == 2 -> chapter3_muse_free
    ; Choice == 3 -> chapter3_muse_leave
    ; writeln('Ungültige Wahl. Bitte wähle 1 oder 2.'), chapter3_muse_encounter
    ).

chapter3_muse_speak :-
    assertz(muse_state(spoken)),
    Lines = [
        'Du trittst näher. Die Ketten der Muse schimmern und pulsieren.',
        '„Du suchst den Weg, Sterblicher? Ich kenne ihn. Aber Wissen hat seinen Preis.“',
        'Sie verlangt, dass du ihr einen Teil deiner eigenen Erinnerungen an Beatrice gibst, um den Weg zu offenbaren. Dies würde deine Bindung an Beatrice schwächen, aber den Weg ebnen.',
        'Was tust du? (annehmen/ablehnen)'
    ],
    pause_print(Lines),
    writeln('Hinweis: Diese Interaktion hat Auswirkungen auf deinen Charakter, die noch nicht vollständig im Spiel umgesetzt sind. Wähle „annehmen“ für den Fortgang.'),
    read_line_to_string(user_input, Input),
    normalize_space(string(CleanInput), Input),
    ( member(CleanInput, ["annehmen", "annehmen"]) ->
        Lines2 = [
            'Du schließt die Augen und konzentrierst dich auf deine Erinnerungen an Beatrice.',
            'Ein Teil von dir zögert, doch der Wunsch, sie zu retten, ist größer.',
            'Du spürst, wie eine Welle der Wärme von dir weicht, als die Muse ihre Hand ausstreckt und etwas aus deinem Geist zieht.',
            '„Der Pfad liegt jenseits des großen Wächters… doch es gibt einen schmalen Seitengang, wenn dein Blick klar ist.“',
            '(+1 Treffsicherheit, Muse gibt Hinweis auf Abkürzung)'
        ],
        pause_print(Lines2),
        player_state(char(N,HP,MaxHP,AC,Pos,Abs,Str,Acc,DMod,SMod,CT)),
        NewAcc is Acc + 1, % Reward: +1 Accuracy
        retract(player_state(_)),
        assertz(player_state(char(N,HP,MaxHP,AC,Pos,Abs,Str,NewAcc,DMod,SMod,CT))),
        writeln('Deine Treffsicherheit hat sich um 1 erhöht!'),
        chapter3_karontheus_intro(secret) % Gehe zum Bosskampf, aber mit Möglichkeit für Abkürzung
    ; member(CleanInput, ["ablehnen", "ablehnen"]) ->
        Lines2 = [
            'Du schüttelst den Kopf. „Ich werde meine Erinnerungen nicht opfern. Beatrice ist es wert, dass ich den schwierigeren Weg gehe.“',
            'Die Muse lächelt traurig. „Dann sei es so, Wanderer. Mögen deine Erinnerungen dich leiten.“'
        ],
        pause_print(Lines2),
        chapter3_karontheus_intro(normal) % Gehe zum Bosskampf ohne Abkürzung
    ;
        writeln('Ungültige Eingabe. Bitte gib "annehmen" oder "ablehnen" ein.'),
        chapter3_muse_speak
    ).

chapter3_muse_free :-
    assertz(muse_state(freed)),
    Lines = [
        'Du versuchst, die leuchtenden Ketten der Muse zu berühren. Ein stechender Schmerz durchfährt deine Hand, doch du hältst stand.',
        'Mit einem Aufschrei zersplittern die Lichtketten. Die Muse steht auf, ihre Augen leuchten vor Dankbarkeit – und einem Funken dunkler Macht.',
        '„Du wagst es, mich zu befreien? Eine mutige, aber törichte Tat. Doch deine Entschlossenheit ist rein. Ich gewähre dir, was ich kann.“',
        '(Du erleidest 10 Schaden, +1 Treffsicherheit durch göttlichen Segen)'
    ],
    pause_print(Lines),
    update_player_hp(-10), % Schaden zufügen
    player_state(char(N,HP,MaxHP,AC,Pos,Abs,Str,Acc,DMod,SMod,CT)),
    NewAcc is Acc + 1, % Reward: +1 Accuracy
    retract(player_state(_)),
    assertz(player_state(char(N,HP,MaxHP,AC,Pos,Abs,Str,NewAcc,DMod,SMod,CT))),
    writeln('Deine Treffsicherheit hat sich um 1 erhöht!'),
    chapter3_karontheus_intro(secret). % Gehe zum Bosskampf, mit Möglichkeit für Abkürzung

chapter3_muse_leave :-
    assertz(muse_state(left)),
    Lines = [
        'Du spürst, dass du hier nichts finden wirst, oder dass die Risiken zu groß sind.',
        'Mit einem letzten Blick auf die gefesselte Muse drehst du dich um und verlässt die Grotte.',
        'Ein kalter Hauch des Zorns scheint dir zu folgen.'
    ],
    pause_print(Lines),
    chapter3_karontheus_intro(normal). % Gehe zum Bosskampf ohne Abkürzung

chapter3_karontheus_intro(PathType) :-
    Lines = [
        'etwas verändert sich.',
        'Der Boden bebt leicht. Der Nebel reißt auf. Der warme, stöhnende Wind wird zum peitschenden Sturm.',
        'Du hörst Flügelschläge.',
        'Nicht weit entfernt erhebt sich aus einer Schlucht ein gewaltiger, humanoider Schatten mit geblähten Flügeln aus Haut und Rauch – gezeichnet von Narben, mit einem Blick, der tiefer reicht als Begierde.',
        'Er ist keine Erscheinung. Kein Geist. Kein Verführer.',
        'Er ist der Wächter dieses Kreises.',
        'Karontheus, der Herr der Verlorenen Leidenschaften',
        'Einst ein Engel der Schönheit, jetzt verzerrt durch die Lust der Menschheit. Er trägt Ketten wie Schmuck, seine Worte reißen alte Wunden auf:',
        '„Du willst weiter? Dann zeige mir, wie stark dein Wille ist. Oder geh unter im Sturm der Sehnsucht!“'
    ],
    pause_print(Lines),
    writeln('= Bosskampf: Karontheus ='),
    ( PathType == secret ->
        writeln('Du hast einen geheimen Pfad entdeckt. Willst du ihn nutzen, um Karontheus zu umgehen? (ja/nein)'),
        read_line_to_string(user_input, Input),
        normalize_space(string(CleanInput), Input),
        ( member(CleanInput, ["ja", "Ja", "JA", "j", "J"]) -> chapter3_skip_karontheus
        ; member(CleanInput, ["nein", "Nein", "NEIN", "n", "N"]) -> chapter3_start_karontheus_fight
        ; writeln('Ungültige Eingabe. Bitte nur "ja" oder "nein".'), chapter3_karontheus_intro(secret) % Wiederhole die Frage
        )
    ;
        chapter3_start_karontheus_fight
    ).

chapter3_skip_karontheus :-
    Lines = [
        'Du nutzt den Hinweis der Muse und findest einen versteckten Riss in der Felswand.',
        'Er ist eng, dunkel und feucht, aber der Wind und die Schreie Karontheus\' erreichen dich hier nicht.',
        'Nach einer Weile des Kriechens und Kletterns stößt du auf eine weitere Öffnung.',
        'Das Licht hier ist anders – kälter, härter.'
    ],
    pause_print(Lines),
    chapter3_after_karontheus_fight.

chapter3_start_karontheus_fight :-
    player_state(Player),
    Enemy = char('Karontheus', 250, 250, 13, 1,
        [
            ability('Sturm der Sehnsucht', 'Ein Wirbelwind aus zerbrochenen Träumen. (Hoher Schaden, hoher Stress)', [1,2], 15, 20, attack, 35, none),
            ability('Peitsche der Begierde', 'Eine Kette aus Leiden schlägt nach dir. (Moderater Schaden, Debuff: Rüstung)', [1,2], 10, 15, attack, 10, armor),
            ability('Verlorene Schönheit', 'Karontheus besinnt sich auf seine einstige Schönheit und heilt sich. (Buff: Heilung)', [1,2], 10, 20, heal, 0, hp)
        ], 0, 0, 0, 0, boss),
    ( start_fight(Player, Enemy) ->
        chapter3_after_karontheus_fight
    ;
        writeln('Du wurdest von Karontheus überwältigt. Deine Leidenschaften haben dich verzehrt... Game Over.'),
        fail % Game Over
    ).

chapter3_after_karontheus_fight :-
    Lines = [
        'Der Boden beginnt zu beben. Der Sturm fällt in sich zusammen.',
        'Karontheus sinkt auf die Knie. Noch einmal spricht er:',
        '„Dein Herz… ist rein genug, um weiterzugehen. Doch die Tiefe wird dich mehr kosten, als du ahnst.“',
        'Hinter seinem zerschlagenen Leib öffnet sich ein uraltes, kreisrundes Portal aus Marmor, umwoben mit Symbolen von Venus, Eros – und Schmerz.',
        'Ein gewaltiger Sog zieht dich hinein.',
        'Virgil tritt neben dich.',
        '„Bereit für die Gier?“',
        'Dann:',
        'Schwarz.'
    ],
    pause_print(Lines),
    start_chapter4_intro.

% --- Kapitel 4: Gier ---
start_chapter4_intro :-
    nl,
    write('Kapitel 4: Gier'), nl,
    write('-----------------'), nl, nl,
    Lines = [
        'Dunkelheit umhüllt dich, schwer wie Blei.',
        'Ein Gefühl von Sog, von Enge – du fällst nicht, du wirst gezogen.',
        'Als deine Füße wieder Boden spüren, riechst du es sofort:',
        'Altes Eisen. Modernde Münzen.',
        'Der Gestank von kaltem Schweiß, verbrannter Haut und altem Papier.',
        'Langsam öffnest du die Augen.',
        'Du stehst in einem riesigen Höhlensystem, dessen Wände aus Goldadern bestehen.',
        'Überall glitzert es. Doch es ist kein Glanz des Lebens. Es ist der Glanz der Gier – stumpf, kalt, besitzergreifend.',
        'In der Ferne hörst du Hämmern.',
        'Zugriffe. Kreischen.',
        'Die Gequälten dieses Kreises sind verdammt, unablässig Reichtum zu schürfen, den sie niemals besitzen dürfen.',
        'Virgil steht neben dir.',
        'Sein Blick ist hart, seine Stimme ruhiger denn je:',
        '„Die Seelen hier haben sich dem Besitzen verschrieben – Gold, Einfluss, Macht.',
        'Jetzt besitzen sie nichts… außer ihrer ewigen Habgier.“',
        'Du erkennst nun:',
        'Zwischen den Gängen und Felsen kriechen Menschen mit goldenen Masken, klammern sich an Erzbrocken, beißen in Steine, prügeln sich um rostige Ringe.',
        'Sie bemerken dich kaum. Ihr Blick ist leer, ihr Wunsch ewig.'
    ],
    pause_print(Lines),
    writeln('Was willst du tun?'),
    writeln('1. „Ich will wissen, was sie dazu getrieben hat…“'),
    writeln('2. „Wo ist der Ausgang? Ich will hier so schnell wie möglich weg.“'),
    read_choice(Choice),
    ( Choice == 1 -> chapter4_speak_to_greedy
    ; Choice == 2 -> chapter4_rush_through
    ; writeln('Ungültige Wahl. Bitte wähle 1 oder 2.'), start_chapter4_intro
    ).

chapter4_speak_to_greedy :-
    writeln('Du näherst dich einem der Gierigen und versuchst, mit ihm zu sprechen.'),
    writeln('Danke für das Spielen der Demo!').

chapter4_rush_through :-
    writeln('Du gehst weiter durch die Tunnel – direkt Richtung Boss.'),
    writeln('Danke für das Spielen der Demo!').

% --- Dynamische Spieler-Update-Prädikate ---

update_player_hp(HPChange) :-
    player_state(char(Name, CurrentHP, MaxHP, AC, Pos, Abs, Stress, Acc, DMod, SMod, CT)),
    NewHP is max(0, min(MaxHP, CurrentHP + HPChange)), % HP kann nicht unter 0 oder über MaxHP gehen
    retract(player_state(char(Name, CurrentHP, MaxHP, AC, Pos, Abs, Stress, Acc, DMod, SMod, CT))),
    assertz(player_state(char(Name, NewHP, MaxHP, AC, Pos, Abs, Stress, Acc, DMod, SMod, CT))),
    ( HPChange < 0 ->
        format('Du verlierst ~w HP. Aktuell: ~w/~w~n', [-HPChange, NewHP, MaxHP])
    ; HPChange > 0 ->
        format('Du erhältst ~w HP. Aktuell: ~w/~w~n', [HPChange, NewHP, MaxHP])
    ; true
    ).

update_player_stress(StressChange) :-
    player_state(char(Name, HP, MaxHP, AC, Pos, Abs, CurrentStress, Acc, DMod, SMod, CT)),
    NewStress is max(0, CurrentStress + StressChange), % Stress kann nicht unter 0 fallen
    retract(player_state(char(Name, HP, MaxHP, AC, Pos, Abs, CurrentStress, Acc, DMod, SMod, CT))),
    assertz(player_state(char(Name, HP, MaxHP, AC, Pos, Abs, NewStress, Acc, DMod, SMod, CT))),
    ( StressChange > 0 ->
        format('Dein Stress steigt um ~w. Aktuell: ~w~n', [StressChange, NewStress])
    ; StressChange < 0 ->
        format('Dein Stress sinkt um ~w. Aktuell: ~w~n', [-StressChange, NewStress])
    ; true
    ).

% Convenience predicates for easier input during the adventure
% Diese Prädikate werden ignoriert, da die Eingabe per Zahl erfolgt.
% ja :- writeln('Bitte wähle eine Option aus der angezeigten Liste (Zahl).'), fail.
% nein :- writeln('Bitte wähle eine Option aus der angezeigten Liste (Zahl).'), fail.
% sarg :- writeln('Bitte wähle eine Option aus der angezeigten Liste (Zahl).').
% tuer :- writeln('Bitte wähle eine Option aus der angezeigten Liste (Zahl).').
