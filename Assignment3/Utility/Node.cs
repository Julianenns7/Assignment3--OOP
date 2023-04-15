using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.Utility
{
    [DataContract]
    public class Node
    {
        [DataMember]
        public Node Next { get; set; }
        
        [DataMember]
        public User Value { get; set; }

        public Node(User value) 
        {
            Value = value;
            Next = null;
        }
        public Node() { }
    }

}
