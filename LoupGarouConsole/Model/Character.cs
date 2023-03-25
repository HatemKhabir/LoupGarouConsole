using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoupGarouConsole.Model
{
    public class Character
    {
       // public Guid RoleID { get; set; }
        public Card RoleName { get; set; }
        public string Description { get; set; }
        public bool CanKill{ get; set; }
        public Character(Card c )
        {
            RoleName = c;
        }
        public enum Card
        {
            Salvador,
            SimpleVillageois,
            Loups
        }
    }
}
