using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Actions;
using System.Collections.Generic;
public class ClanRelationBehavior : CampaignBehaviorBase
{
    public override void RegisterEvents()
    {
        CampaignEvents.OnNewGameCreatedEvent.AddNonSerializedListener(this, OnNewGameCreated);
    }

    private void OnNewGameCreated(CampaignGameStarter starter)
    {
        List<string> heroIds = new List<string>
        {
            "lord_1_25",    // Egwene
            "lord_1_27",    // Nynaeve
            "lord_1_422",   // Blacktower loyalist leader
            "lord_2_11",    // Rhuarc
            "lord_4_23",    // Bashere
            "lord_1_1",     // Elayne
            "lord_3_18_3",  // Darlin
            "lord_3_19_3"   // Belearne (Mayene ruler)
        };

        List<string> darkfriendsIds = new List<string>
        {
            "lord_1_27_3"   // Marzim tiam
        };

        string GaladID = "lord_SE9_l";
        string ElayneID = "lord_1_1";
        string RandId = "lord_1_48_1";
        string IshmaelID = "lord_5_20";

        Hero Rand = Hero.FindFirst(x => x.StringId == RandId);
        Hero Ishmael = Hero.FindFirst(x => x.StringId == IshmaelID);
        Hero Galad = Hero.FindFirst(x => x.StringId == GaladID);
        Hero Elayne = Hero.FindFirst(x => x.StringId == ElayneID);

        if (Rand != null)
        {
            foreach (string id in heroIds)
            {
                Hero hero = Hero.FindFirst(x => x.StringId == id);
                if (hero != null)
                {
                    CharacterRelationManager.SetHeroRelation(Rand, hero, 100);
                }
            }
        }

        if (Ishmael != null)
        {
            foreach (string id in darkfriendsIds)
            {
                Hero hero = Hero.FindFirst(x => x.StringId == id);
                if (hero != null)
                {
                    CharacterRelationManager.SetHeroRelation(Ishmael, hero, 100);
                }
            }
        }

        if (Galad != null && Elayne != null)
        {
            CharacterRelationManager.SetHeroRelation(Elayne, Galad, 100);
        }
    }

    public override void SyncData(IDataStore dataStore) { }
}