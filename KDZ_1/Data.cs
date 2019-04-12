using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerasimenkoER_KDZ3_v2
{


    public class ОПОП
    {
        #region values
        public int _ROWNUM=0;
        
        int _OPOPNumber=0;
        Расположение _adress;
        Phone _PublicPhone = new Phone();
        int _GLOBALID=0;
        string Name="";
        string Address="";
        string ExtraInfo="";
        string X_WGS="", Y_WGS="";
        pair<string,string> Adress { get { return pair<string, string>.makepair<string, string>(adress.AdmArea, adress.District); } set { adress.AdmArea = value.first; adress.District = value.second; } }
        string ROWNUM { get { return "" + _ROWNUM; } set { int.TryParse(value, out _ROWNUM); } }
        string OPOPNumber { get { return "" + _OPOPNumber; } set { int.TryParse(value, out _OPOPNumber); } }
        string AdmArea { get { return adress.AdmArea; } set { adress.AdmArea = value; } }
        string District { get { return adress.District; } set { adress.District = value; } }
        string PublicPhone{ get { return _PublicPhone.get(); } set { _PublicPhone.set(value); } }
        string GLOBALID { get { return "" + _GLOBALID; } set { int.TryParse(value, out _GLOBALID); } }

        #endregion
        public Расположение adress { get { return _adress; } set { _adress = value; } }

        public ОПОП() { }
        public ОПОП(Расположение a)
        {
            adress = a;

        }
        public ОПОП(IEnumerable<string> i)
        {
            int n = 0;
            foreach (var s in i)
            {
                this[n++] = s;
            }
        }
        public ОПОП(IEnumerable<string> i, Расположение a):this(a)
        {
            int n = 0;
            foreach (var s in i)
            {
                this[n++] = s;
            }
        }

        /// <summary>
        /// GET AND SET
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public string this [int n]
        {
            get {
                switch (n)
                {
                    case (0): return ROWNUM;
                    case (1): return Name;
                    case (2): return OPOPNumber;
                    case (3): return AdmArea;
                    case (4): return District;
                    case (5): return Address;
                    case (6): return PublicPhone;
                    case (7): return ExtraInfo;
                    case (8): return X_WGS;
                    case (9): return Y_WGS;
                    case (10): return GLOBALID;
                }
                return "";
            }
            set {
                switch (n)
                {
                    case (0): ROWNUM = value; break;
                    case (1): Name = value; break;
                    case (2): OPOPNumber = value; break;
                    case (3): AdmArea = value; break;
                    case (4): District = value; break;
                    case (5): Address = value; break;
                    case (6): PublicPhone = value; break;
                    case (7): ExtraInfo = value; break;
                    case (8): X_WGS = value; break;
                    case (9): Y_WGS = value; break;
                    case (10): GLOBALID = value; break;
                }
            }
        }


    }
    public class Расположение
    {
        public string AdmArea="";
        public string District="";
    }

    public class Phone
    {
        string number="";

        public string get()
        {
            return number;
        }
        public void set(string num) //(499) 367-49-82
        {
            //if (num.Length != 10) throw new ApplicationException("Not a correct phone number");
            //int num2 = int.Parse(String.Join("",parce(num).Reverse()));
            string num2 = /*int.Parse*/(parce(num));
            string strok = "";
            int i = -1;
            while(++i!=-1 && num2.Length>i)
            {
                strok += "" + (num2[num2.Length - 1 - i]);// % 10);
                //num2 /= 10;
                if (i == 1) { strok += "-"; }
                if (i == 3) { strok += "-"; }
                if (i == 6) { strok += " )"; }
                if (i == 9) { strok += "("; }
            }
            number = String.Join("", strok.Reverse());
        }
        public string parce(string s="")
        {
            if(s.Length==0) { s = number; }
            string strok = "";
            foreach(char c in s)
            {
                if(c>='0' && c <= '9')
                {
                    strok += c;
                }
            }
            return strok;//(number.Trim(strok.ToCharArray()));
        }
    }



    class Data
    {
        public bool flagmb = false;
        public bool rewrite = false;
        public bool issaved = true;
        public bool isaded = false;
        public bool sne = false, ene = false;
        public string name = "";
        public List<List<string>> data = null;
        public string[] datas = null;
        public char separ = ';';
        public Encoding encode = Encoding.Default;
        public int sn = 1;
        public int en = -1;
    }


}
