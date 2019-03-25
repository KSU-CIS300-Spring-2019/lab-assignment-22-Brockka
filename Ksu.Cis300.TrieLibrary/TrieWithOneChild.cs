using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.TrieLibrary
{
    public class TrieWithOneChild : ITrie
    {
        /// <summary>
        /// bool to see if in string
        /// </summary>
        private bool _contains;

        private ITrie _child;

        private char _label;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="b"></param>
        public TrieWithOneChild(string s, bool b)
        {
            if (s== "" || s[0] < 'a' || s[0] > 'z')
            {
                throw new ArgumentException();
            }
            _contains = b;
            _label = s[0];
            _child = new TrieWithNoChildren().Add(s.Substring(1));
        }

        public ITrie Add(string s)
        {
            if(s == "")
            {
                _contains = true;
                return this;
            }
            else if(s[0] < 'a' || s[0] > 'z')
            {
                throw new ArgumentException();
            }
            else if(s[0] == _label)
            {
                s = s.Substring(1);
                _child = _child.Add(s);
                return this;
            }
            else
            {
                TrieWithManyChildren children = new TrieWithManyChildren(s, _contains, _label, _child);
                return children;
            }
        }

        public bool Contains(string s)
        {
            if(s == "")
            {
                return _contains;
            }
            else if(s[0] == _label)
            {
                return _child.Contains(s.Substring(1));
            }
            return false;
        }
    }

}
