using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerasimenkoER_KDZ3_v2
{
    class AhoCorasik
    {
        

        //int NMAX = 1000;

        public AhoCorasik() { }
        public AhoCorasik(IEnumerable which, int nmax = 1000)
        {
            init(nmax);
            foreach(string i in which)
            {
                add_string(i);
            }
        }

        private int findInString(string s, string[] w)
        {
            int i = 0;
            for (i = 0; i < w.Length; i++)
            {
                if (s == w[i]) return i;
            }
            return i;
        }

        /// <summary>
        /// Find substring in string 
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public vector<pair<vector<int>,string>> find(string where)
        {
            int v = 0;
            vector<pair<vector<int>,string>> n = new vector<pair<vector<int>, string>>();
            for(int i = 0; i < where.Length; i++)
            {
                v = go(v, where[i]);
                if (t[v].leaf)
                {
                    int j = 0;
                    bool flag = true;
                    for(j = 0; j < n.size(); ++j)
                    {
                        if(n[j].second == t[v].leafs)
                        {
                            n[j].first.append(i - t[v].leafs.Length + 1);
                            flag = false;
                        }
                    }
                    if (flag) {
                        n.append(new pair<vector<int>, string>());
                        j = n.size() - 1;
                        //n[j] = new pair<vector<int>, string>();
                        n[j].second=t[v].leafs;
                        //n[j].setsecond(t[v].leafs);
                        //vector<int> _ = new vector<int>();
                        n[j].first=new vector<int>();//_;
                        //n[j].setfirst(_);
                        n[j].first.append(i - t[v].leafs.Length + 1);
                    }
                }
            }

            return n;
        }

        /// <summary>
        /// Find substring in collection string
        /// </summary>
        /// <param name="ii">String</param>
        /// <param name="isienumerable">Fictive parameter</param>
        /// <returns></returns>
        public IEnumerable<vector<pair<vector<int>, string>>> find(IEnumerable ii, bool isienumerable)
        {
            int v = 0;
            int iin = -1;
            vector<pair<vector<int>, string>> n = new vector<pair<vector<int>, string>>();
            foreach (string where in ii)
            {

                ++iin;
                for (int i = 0; i < where.Length; i++)
                {
                    v = go(v, where[i]);
                    if (t[v].leaf)
                    {
                        int j = 0;
                        bool flag = true;
                        for (j = 0; j < n.size(); ++j)
                        {
                            if (n[j].second == t[v].leafs)
                            {
                                n[j].first.append(i - t[v].leafs.Length + 1);
                            }
                        }
                        if (flag)
                        {
                            n.append(new pair<vector<int>, string>());
                            j = n.size() - 1;
                            //n[j] = new pair<vector<int>, string>();
                            n[j].second=t[v].leafs;
                            n[j].first = new vector<int>();
                            n[j].first.append(i - t[v].leafs.Length + 1);
                        }
                    }
                }
                yield return n;
            }

        }








        struct vertex
        {
            public int[] next; //adress
            public bool leaf;
            public string leafs;
            public int p;
            public char pch;
            public int link;
            public int[] go; //adress
            //public int myadress;
        };
        void build(int nmax = 1000) {
            t = new vertex[nmax + 1];
            //for(int i = 0; i < nmax + 1; i++)
            //{
            //    t[i] = new vertex();
            //}
        }
        vertex[] t;
        int sz;

        void memset(out int[] p, int _, int[] __)
        {
            p = new int[char.MaxValue];
            for (int i = 0; i < p.Length; ++i)
            {
                p[i] = -1;
            }
        }

        void init(int nmax = 1000)
        {
            build(nmax);
            t[0].p = t[0].link = -1;
            //t[0].myadress = 0;
            memset(out t[0].next, 255, t[0].next);
            memset(out t[0].go, 255, t[0].go);
            sz = 1;
        }

        void add_string(string s) {
	        int v = 0;
	        for (int i=0; i<s.Length; ++i) {
		        char c = s[i];
		        if (t[v].next[c] == -1) {
			        memset(out t[sz].next, 255,  t[sz].next); //ERROR
                memset(out t[sz].go, 255,  t[sz].go);
                t[sz].link = -1;
			        t[sz].p = v;
			        t[sz].pch = c;
			        t[v].next[c] = sz++;
		        }
            v = t[v].next[c];
	        }
        t[v].leaf = true;
        t[v].leafs = s;
        }
 
        //int go(int v, char c);

        int get_link(int v)
        {
            if (t[v].link == -1)
                if (v == 0 || t[v].p == 0)
                    t[v].link = 0;
                else
                    t[v].link = go(get_link(t[v].p), t[v].pch);
            return t[v].link;
        }

        int go(int v, char c)
        {
            if (t[v].go[c] == -1)
                if (t[v].next[c] != -1)
                    t[v].go[c] = t[v].next[c];
                else
                    t[v].go[c] = v == 0 ? 0 : go(get_link(v), c);
            return t[v].go[c];
        }

    }
}
