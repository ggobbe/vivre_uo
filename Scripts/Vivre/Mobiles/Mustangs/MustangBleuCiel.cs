using System;
using Server;

namespace Server.Mobiles
{
	public class MustangBleuCiel : BaseMustang
	{
	
		[Constructable]
		public MustangBleuCiel() : base( 0x78, 0x3EAF, AIType.AI_Melee, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
		
		Hue = 0x0263;
		Name = "Mustang Bleu Ciel";
		
		MinTameSkill = 74.1;
		}

		public MustangBleuCiel( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}

