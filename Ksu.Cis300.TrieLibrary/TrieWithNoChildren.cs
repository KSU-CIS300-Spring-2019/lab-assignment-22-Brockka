using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.TrieLibrary
{
    public class TrieWithNoChildren : ITrie
    {
        private bool _empty = false;

        public ITrie Add(string s)
        {
            if (s == "")
            {
                _empty = true;
                return this;
            }
            else
            {
                TrieWithOneChild children = new TrieWithOneChild(s,_empty);
                return children;
            }
        }

        public bool Contains(string s)
        {
            if(s == "")
            {
                return _empty;
            }
            return false;
        }
    }
}
