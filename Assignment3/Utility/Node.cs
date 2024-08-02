using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Assignment3.Utility
{
    [DataContract]
    internal class Node
    {
        [DataMember]
        public User Value { get; set; }
        [DataMember]
        public Node Next { get; set; }

        public Node(User value)
        {
            Value = value;
            Next = null;
        }
    }
}