using SaveOurShip2;
using BioShip;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Verse;

namespace RimWorld
{
    public class OcularPerk : IMutation
    {
        bool IHediff.ShouldAddTo(CompBuildingBodyPart target)
        {
            bool ret = false;
            ret = ret || (target.parent.TryGetComp<CompShipHeart>() != null);
            ret = ret || (target.parent.TryGetComp<CompMutationWorker>() != null);
            return ret;
        }

        void IHediff.Apply(CompBuildingBodyPart target)
        {
            if (target.parent.TryGetComp<CompShipHeart>() != null)
            {
                CompShipHeart heart = target.parent.TryGetComp<CompShipHeart>();
                heart.defs.TryGetValue("spinalTurretOptions", new List<ThingDef>())
                    .Add(ThingDef.Named("GiantEyeLaser"));
            }
            if (target.parent.TryGetComp<CompMutationWorker>() != null)
            {
                CompMutationWorker mut = target.parent.TryGetComp<CompMutationWorker>();
                mut.quirkPossibilities.Remove(this);
            }

        }
        void IHediff.Remove(CompBuildingBodyPart target)
        {

        }
        List<IMutation> IMutation.GetMutationsForTier(string tier, List<IMutation> existingMutations) {
            return new List<IMutation>() { };
        }
        String IMutation.GetTier() {
            return "tier1";
        }
        String IMutation.GetDescription()
        {
            return "";
        }
        Texture2D IMutation.GetIcon()
        {
            return null;
        }
        void IExposable.ExposeData()
        {

        }

    }
}