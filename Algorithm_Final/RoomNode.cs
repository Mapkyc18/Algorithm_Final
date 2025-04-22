using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_Final
{
    public class RoomNode
    {
        public int RoomID;
        public List<RoomNode> Paths = new List<RoomNode>();
        public RoomNode(int id) { RoomID = id; }

    }
}
