using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverWatchBuddy
{
    public enum HeroName
    {
        NONE,
        ASHE,
        ANA,
        BASTION,
        DVA,
        GENJI,
        HANZO,
        MEI,
        PHARAH,
        DOOMFIST,
        REAPER,
        SOLIDER76,
        SOMBRA,
        JUNKRAT,
        ROADHOG,
        BRIGITTE,
        LUCIO,
        MERCY,
        MOIRA,
        ZENYATTA,
        TRACER,
        WIDOWMAKER,
        SYMMETRA,
        TORBJORN,
        WINSTON,
        REINHARDT,
        ORISA,
        HAMMOND,
        ZARYA,
        MCCREE
    }

    public enum roleName
    {
        NONE,
        HEALER,
        TANK,
        DAMAGE
    }

    public class Hero
    {
        private HeroName _name;
        private roleName _role;
        private List<HeroName> _counter;
        private string _description;

        public HeroName Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public roleName Role
        {
            get { return _role; }
            set { _role = value; }
        }
      

        public List<HeroName> Counter
        {
            get { return _counter; }
            set { _counter = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public Hero()
        {
            _counter = new List<HeroName>();
        }

      
    } 
}
