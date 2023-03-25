using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoupGarouConsole.Model
{
    public class Player : IEnumerable
    {
        public Guid PlayerId { get; set; }
        public string Name { get; set; }    
        public int Role { get; set; }
        public bool IsAlive { get; set; }
        public bool IsProtected { get; set; }
        public Player(string name)
        {
            PlayerId= Guid.NewGuid();   
            Name = name;
            IsAlive= true;
        }
        public void AssignRole(int n)
        {
            Role = n;
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
