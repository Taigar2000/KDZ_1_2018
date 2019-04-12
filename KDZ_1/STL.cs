using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerasimenkoER_KDZ3_v2
{
    //class STL
    //{
    //}

    class pair<T1, T2>
        //where T1 : IComparable
        //where T2 : IComparable
    {
        public T1 first;
        public T2 second;
        public pair() { }
        public pair(T1 firste, T2 seconde){
            first = firste;
            second = seconde;
        }

        public static pair<TT1,TT2> makepair<TT1,TT2>(TT1 first, TT2 second)
        {
            return new pair<TT1, TT2>(first, second);
        }

        public void setfirst(T1 w)
        {
            first = w;
        }
        public void setsecond(T2 w)
        {
            second = w;
        }

        //public static bool operator ==(pair<T1, T2> a, pair<T1, T2> b)
        //{
        //    return a.first.CompareTo(b.first)==0 && a.second.CompareTo(b.second)==0;
        //}
        //public static bool operator !=(pair<T1, T2> a, pair<T1, T2> b)
        //{
        //    return !(a==b);
        //}

        //public static bool operator ==(pair<string, string> a, pair<string, string> b)
        //{
        //    return a.first.CompareTo(b.first)==0 && a.second.CompareTo(b.second)==0;
        //}
        //public static bool operator !=(pair<string, string> a, pair<string, string> b)
        //{
        //    return !(a==b);
        //}

    }

    //struct pair
    //{
    //    public int first;
    //    public string second;
    //    public void setsecond(string w)
    //    {
    //        second = w;
    //    }
    //}

    struct vector<T>
    {
        List<T> e;
        int length;
        public void fill(List<T> c)
        {
            e = c;
            length = c.Count;
        }
        public int size()
        {
            return length;
        }
        public T this [int n]
        {
            get
            {
                return e[n];
            }
            set
            {
                e[n] = value;
            }
        }
        public void append(T v)
        {
            if (e == null) { e = new List<T>(); }
            e.Add(v);
            ++length;
        }
        public void remove(int n)
        {
            e.RemoveAt(n);
            --length;
        }
        public void reverse()
        {
            e.Reverse();
        }
        public string tostring(string separator = "")
        {
            string s = "";
            for(int i = 0; i < length; ++i)
            {
                s += e[i] + separator;
            }
            return s;
        }
        public T[] toarray()
        {
            return e.ToArray();
        }
    }

}
