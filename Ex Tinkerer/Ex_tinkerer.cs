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
        Hero wanderer = Hero.FindFirst(x => x.StringId == "Ex_tuatha_an_companion");

        if (wanderer != null)
        {
            wanderer.HeroDeveloper.AddAttribute(DefaultCharacterAttributes.Vigor, 5, false);
            wanderer.HeroDeveloper.AddAttribute(DefaultCharacterAttributes.Control, 3, false);
            wanderer.HeroDeveloper.AddAttribute(DefaultCharacterAttributes.Endurence, 3, false);
            wanderer.HeroDeveloper.AddAttribute(DefaultCharacterAttributes.Cunning, 1, false);
            wanderer.HeroDeveloper.AddAttribute(DefaultCharacterAttributes.Social, 2, false);
            wanderer.HeroDeveloper.AddAttribute(DefaultCharacterAttributes.Intelligence, 2, false);

            wanderer.HeroDeveloper.AddFocus(DefaultSkills.OneHanded, 4, false);
            wanderer.HeroDeveloper.AddFocus(DefaultSkills.Polearm, 2, false);
            wanderer.HeroDeveloper.AddFocus(DefaultSkills.Medicine, 2, false);
            wanderer.HeroDeveloper.AddFocus(DefaultSkills.Throwing, 3, false);
            wanderer.HeroDeveloper.AddFocus(DefaultSkills.Athletics, 2, false);
            wanderer.HeroDeveloper.AddFocus(DefaultSkills.Bow, 2, false);
            wanderer.HeroDeveloper.AddFocus(DefaultSkills.Engineering, 2, false);
            wanderer.HeroDeveloper.AddFocus(DefaultSkills.Leadership, 1, false);
            wanderer.HeroDeveloper.AddFocus(DefaultSkills.Scouting, 4, false);
        
        }
    }

    public override void SyncData(IDataStore dataStore)
    {
    }
}