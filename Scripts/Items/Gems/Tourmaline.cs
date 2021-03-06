using System;
using Server;

namespace Server.Items
{
    public class Tourmaline : BaseGem
    {

		public override double DefaultWeight
		{
			get { return 0.1; }
		}

		[Constructable]
		public Tourmaline() : this( 1 )
		{
		}

		[Constructable]
		public Tourmaline( int amount ) : base( 0xF2D )
		{
			Stackable = true;
			Amount = amount;
            Gems = GemType.Tourmaline;
		}

		public Tourmaline( Serial serial ) : base( serial )
		{
		}

		

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 1 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
            if (version < 1)
                Gems = GemType.Tourmaline;
		}
	}
}