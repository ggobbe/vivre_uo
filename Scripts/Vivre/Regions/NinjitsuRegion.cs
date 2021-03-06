﻿using System.Xml;
using Server.Spells.Seventh;
using Server.Spells.Fourth;
using Server.Spells.Sixth;
using Server.Spells.Chivalry;
using Server.ServerSeasons;

namespace Server.Regions
{
    public class NinjitsuRegion : BaseRegion
    {
        private Point3D m_EntranceLocation;
        private Map m_EntranceMap;

        public Point3D EntranceLocation { get { return m_EntranceLocation; } set { m_EntranceLocation = value; } }
        public Map EntranceMap { get { return m_EntranceMap; } set { m_EntranceMap = value; } }

        public NinjitsuRegion(XmlElement xml, Map map, Region parent)
            : base(xml, map, parent)
        {
            XmlElement entrEl = xml["entrance"];

            Map entrMap = map;
            ReadMap(entrEl, "map", ref entrMap, false);

            if (ReadPoint3D(entrEl, entrMap, ref m_EntranceLocation, false))
                m_EntranceMap = entrMap;
        }

        public override bool AllowHousing(Mobile from, Point3D p)
        {
            return false;
        }

        public override void AlterLightLevel(Mobile m, ref int global, ref int personal)
        {
            global = LightCycle.NightLevel;

            if (m == null || m.AccessLevel <= AccessLevel.Counselor)
                personal = 0;
        }

        public override bool CanUseStuckMenu(Mobile m)
        {
            return false;
        }

        public override bool OnBeginSpellCast(Mobile m, ISpell s)
        {
            if ((s is GateTravelSpell || s is RecallSpell || s is MarkSpell || s is SacredJourneySpell) && m.AccessLevel == AccessLevel.Player)
            {
                m.SendMessage("You cannot cast that spell here.");
                return false;
            }
            return base.OnBeginSpellCast(m, s);
        }
    }
}