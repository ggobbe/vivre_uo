﻿using System;
using Server;
using Server.Items;
using Server.Targeting;

namespace Server.Items
{
    public class RepondRelic : Item
    {
        [Constructable]
        public RepondRelic()
            : base(0x5746)
        {
            Name = "Une langue de géant";
            Weight = 2.0;
        }

        public RepondRelic(Serial serial)
            : base(serial)
        {
        }

        public override void OnDoubleClick(Mobile from)
        {
            from.SendMessage("Dans quelle forge voulez-vous la jeter?");
            from.BeginTarget(-1, false, TargetFlags.None, new TargetCallback(DropTarget));
        }
        
        public void DropTarget(Mobile from, object obj)
        {
            if(!(obj is SlayerForge))
            {
                from.SendMessage("Ceci n'est pas une forge adéquate");
                return;
            }

            SlayerForge forge = (SlayerForge)obj;

            if(forge.SuperSlayer != SuperSlayerType.None)
            {
                from.SendMessage("Cette forge contient déjà une relique");
                return;
            }

            if (!(forge.CanAddRelic))
            {
                from.SendMessage("Cette forge ne peut accepter de relique");
                return;
            }

            from.SendMessage("Vous jetez la relique dans la forge");
            forge.SuperSlayer = SuperSlayerType.Repond;
            this.Delete();
        }
        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
}
