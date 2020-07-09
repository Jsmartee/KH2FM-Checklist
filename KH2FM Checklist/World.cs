using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace KH2FM_Checklist
{
    public class World
    {
        public World(string name, List<string> checks)
        {
            _worldName = name;
            _checklist = checks;
            _totalChecks = checks.Count;
        }

        //Name of world
        private string _worldName;
        public string WorldName
        {
            get { return _worldName; }
            set { _worldName = value; }
        }

        //List of checks in world
        private List<string> _checklist;
        public List<string> Checklist
        {
            get { return _checklist; }
            set { _checklist = value; }
        }

        //Total number of checks
        private int _totalChecks;
        public int TotalChecks
        {
            get { return _totalChecks; }
            set { _totalChecks = value; }
        }
    }
}
