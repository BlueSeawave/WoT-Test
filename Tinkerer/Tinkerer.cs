using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.CharacterDevelopment;
using TaleWorlds.Core;

public class WandererStatsBehavior : CampaignBehaviorBase
{
    public override void RegisterEvents()
    {
        CampaignEvents.OnNewGameCreatedEvent.AddNonSerializedListener(this, OnNewGameCreated);
    }

    private void OnNewGameCreated(CampaignGameStarter starter)
    {
        Hero wanderer = Hero.FindFirst(x => x.StringId == "Tuatha_an_companion");

        if (wanderer != null)
        {
            wanderer.HeroDeveloper.AddAttribute(DefaultCharacterAttributes.Vigor, 1, false);
            wanderer.HeroDeveloper.AddAttribute(DefaultCharacterAttributes.Control, 1, false);
            wanderer.HeroDeveloper.AddAttribute(DefaultCharacterAttributes.Endurence, 3, false);
            wanderer.HeroDeveloper.AddAttribute(DefaultCharacterAttributes.Cunning, 1, false);
            wanderer.HeroDeveloper.AddAttribute(DefaultCharacterAttributes.Social, 5, false);
            wanderer.HeroDeveloper.AddAttribute(DefaultCharacterAttributes.Intelligence, 5, false);

            wanderer.HeroDeveloper.AddFocus(DefaultSkills.Trading, 4, false);
            wanderer.HeroDeveloper.AddFocus(DefaultSkills.Steward, 3, false);
            wanderer.HeroDeveloper.AddFocus(DefaultSkills.Medicine, 4, false);
            wanderer.HeroDeveloper.AddFocus(DefaultSkills.Charm, 3, false);
            wanderer.HeroDeveloper.AddFocus(DefaultSkills.Athletics, 2, false);
            wanderer.HeroDeveloper.AddFocus(DefaultSkills.Engineering, 3, false);
            wanderer.HeroDeveloper.AddFocus(DefaultSkills.Leadership, 1, false);
            wanderer.HeroDeveloper.AddFocus(DefaultSkills.Scouting, 1, false);
        
        }
                // 1. NPC opening line
        starter.AddDialogLine(
            "Tuatha_an_companion_intro_1",
            "start",
            "Tuatha_an_companion_intro_1_player_response",
            "{=Tuatha_an_companion_intro_1}My name is Myriel Songseeker, do you know the song?",
            IsTuatha_an_companion,
            null,
            110
        );

        // 2. Player response option
        starter.AddPlayerLine(
            "Tuatha_an_companion_ask_backstory",
            "Tuatha_an_companion_intro_1_player_response",
            "Tuatha_an_companion_backstory_reply",     // Longer tree
            "{=Tuatha_an_companion_ask_backstory}I do not know the song? What is one of the Tuatha'an doing here?",
            null, null
        );

        starter.AddPlayerLine(
            "Tuatha_an_companion_quick_recruitment",
            "Tuatha_an_companion_intro_1_player_response",
            "close_window",        // Quick recruitment
            "{=Tuatha_an_companion_quick_recruitment}I don't know anything about some silly song. Will you join me or not?",
            null, null
        );

        // 3. NPC follow-up / backstory line
        starter.AddDialogLine(
            "Tuatha_an_companion_backstory_reply",
            "Tuatha_an_companion_backstory_reply",
            "Tuatha_an_companion_backstory_continue",
            "{=Tuatha_an_companion_backstory_reply}Me and my family have wandered all over the westlands seeking the song. I dont need to tell you how much suffering we saw, I am sure you have seen your own fair share. My people wandered on",
            IsTuatha_an_companion,
            null,
            110
        );
        starter.AddDialogLine(
            "Tuatha_an_companion_backstory_continue",
            "Tuatha_an_companion_backstory_continue",
            "Tuatha_an_companion_player_recruitment",
            "{=Tuatha_an_companion_backstory_continue}I decided to remain, perhaps if I help those in need I will get closer to finding the song?"
             IsTuatha_an_companion,
            null,
            110
            )
        starter.AddPlayerLine(
            "Tuatha_an_companion_player_recruitment",
            "Tuatha_an_companion_player_recruitment",
            "close_window",
            "{=Tuatha_an_companion_player_recruitment}Maybe? If you come with me, I will do my best to help you find the song"
            null, null

        )

    }

    public override void SyncData(IDataStore dataStore)
    {
    }
}