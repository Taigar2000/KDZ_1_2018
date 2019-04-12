using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using GerasimenkoER_KDZ3_v2;

namespace GerasimenkoER_KDZ3_v2
{

    [System.Serializable]
    public class CSVException : ApplicationException
    {
        public CSVException() { }
        public CSVException(string message) : base(message) { }
        public CSVException(string message, Exception inner) : base(message, inner) { }
        protected CSVException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

    public class CSVconv
    {

        #region f*f
        /// <summary>
        /// Read lines from file
        /// </summary>
        /// <param name="path">Path to file</param>
        /// <param name="n">Number of readed lines (read all -1)</param>
        /// <param name="encode">Encoding of file</param>
        /// <exception name="CSVException"></exception>
        /// <returns>Array of strings from file</returns>
        public static string[] fscanf(string path, Encoding encode = null, int n = -1)
        {
            string str = $@"Can't read all lines from file {path}";
            StreamReader f = null;
            if (encode == null) { encode = Encoding.Default; }
            try
            {
                //FileStream file = new FileStream(path, FileMode.Open);
                if (n == -1)
                {

                    return File.ReadAllLines(path,encode);
                }
                str = $@"Can't read {n} lines from file {path}";
                f = File.OpenText(path);
                string[] s = new string[n];
                for (int i = 0; i < n; i++)
                {
                    s[i] = f.ReadLine();
                }
                return s;
            }
            catch (ArgumentNullException e)
            {
                throw new CSVException(str + " because you give null string instead path", e);
            }
            catch(ArgumentException e)
            {
                throw new CSVException(str + " because you give path in wrong format", e);
            }
            catch (PathTooLongException e)
            {
                throw new CSVException(str + " because given path is too long", e);
            }
            catch (DirectoryNotFoundException e)
            {
                throw new CSVException(str + " because you give path to nonexistent directory", e);
            }
            catch (FileNotFoundException e)
            {
                throw new CSVException(str + " because you give path to nonexistent file", e);
            }
            catch (IOException e)
            {
                throw new CSVException(str + " because program has error when reading data from file", e);
            }
            catch (UnauthorizedAccessException e)
            {
                throw new CSVException(str + " because your permissions is insufficient to open this file", e);
            }
            catch (NotSupportedException e)
            {
                throw new CSVException(str + " because stream does not support invoked functionality", e);
            }
            catch (System.Security.SecurityException e)
            {
                throw new CSVException(str + " because program take security error", e);
            }
            catch (Exception e)
            {
                throw new CSVException(str + "Unknown exception", e);
            }
            finally
            {
                f?.Close();
            }
            return null;
        }

        /// <summary>
        /// Write lines to file
        /// </summary>
        /// <param name="path">Path to file</param>
        /// <param name="es">Array of strings which needed to write to this file</param>
        /// <param name="rewrite">Rewrite file (true) or append data to the end of file (false)</param>
        public static void fprintf(string path, string[] es, bool rewrite=false, Encoding encode = null)
        {
            string str = $@"Can't write all lines from file {path}";
            if (encode == null) { encode = Encoding.Default; }
            //StreamReader f = null;
            try
            {
                //FileStream file = new FileStream(path, FileMode.Open);
                if (!File.Exists(path)) { rewrite = true; }
                if (rewrite) { 
                    File.WriteAllLines(path,es,encode);
                    return;
                }
                else
                {
                    File.AppendAllLines(path, es, encode);
                    return;
                }
            }
            catch (ArgumentNullException e)
            {
                throw new CSVException(str + " because you give null string instead path", e);
            }
            catch (ArgumentException e)
            {
                throw new CSVException(str + " because you give path in wrong format", e);
            }
            catch (PathTooLongException e)
            {
                throw new CSVException(str + " because given path is too long", e);
            }
            catch (DirectoryNotFoundException e)
            {
                throw new CSVException(str + " because you give path to nonexistent directory", e);
            }
            catch (FileNotFoundException e)
            {
                throw new CSVException(str + " because you give path to nonexistent file", e);
            }
            catch (IOException e)
            {
                throw new CSVException(str + " because program has error when writing data to file", e);
            }
            catch (UnauthorizedAccessException e)
            {
                throw new CSVException(str + " because your permissions is insufficient to open this file", e);
            }
            catch (NotSupportedException e)
            {
                throw new CSVException(str + " because stream does not support invoked functionality", e);
            }
            catch (System.Security.SecurityException e)
            {
                throw new CSVException(str + " because program take security error", e);
            }
            catch (Exception e)
            {
                throw new CSVException(str + "Unknown exception", e);
            }
            finally
            {
                //f.Close();
            }
            return;
        }

        #endregion

        /// <summary>
        /// Load CSV file and return List of List of str
        /// </summary>
        /// <param name="path">Path to file</param>
        /// <param name="c">Separator</param>
        /// <returns>Data for cells in table</returns>
        public static List<List<string>> LoadCSVtoStr(string path, char c=',', Encoding encode=null)
        {
            List<List<string>> res = new List<List<string>>();
            string[] s;
            try
            {
                s = fscanf(path,encode);

            }
            catch (CSVException e) {
                throw e;
            }
            catch(Exception e)
            {
                throw new CSVException(null, e);
            }

            for (int i = 0; i < s.Length; i++)
            {
                res.Add(ConvertCSVlinetoListstr(s[i], c));
            }
            res.Add(new List<string>());
            return res;
        }

        /// <summary>
        /// Save data from table to CSV file
        /// </summary>
        /// <param name="path">Path to file</param>
        /// <param name="s">Data from cells of table</param>
        /// <param name="c">CSV or another separator</param>
        /// <param name="rewrite">Rewrite or append</param>
        public static void SaveStrtoCSV(string path, List<List<string>> s, char c = ',', bool rewrite = false, Encoding encode = null)
        {
            string[] se = new string[s.Count-1];
            for(int i = 0; i < s.Count-1; i++)
            {
                se[i] = ConvertListstrtoCSVline(s[i], c);
            }
            try
            {
                fprintf(path,se,rewrite,encode);

            }
            catch (CSVException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw new CSVException(null, e);
            }
            
        }

        /// <summary>
        /// Save data from table to CSV file
        /// </summary>
        /// <param name="path">Path to file</param>
        /// <param name="s">Data from rows of table</param>
        /// <param name="c">CSV or another separator</param>
        /// <param name="rewrite">Rewrite or append</param>
        public static void SaveStrtoCSV(string path, System.Windows.Forms.DataGridViewRowCollection s, char c = ',', bool rewrite = false, Encoding encode = null, string header= "")
        {
            if (header == "")
            {
                header = "ROWNUM" + c + "Name" + c + "OPOPNumber" + c + "AdmArea" + c + "District" + c + "Address" + c + "PublicPhone" + c + "ExtraInfo" + c + "X_WGS" + c + "Y_WGS" + c + "GLOBALID";
            }
            List<string> se = new List<string>();
            se.Add(header);
            for (int i = 0; i < s.Count-1; i++)
            {
                if (s[i] == null) {
                    continue;
                }
                if(s[i].Visible)
                    se.Add(ConvertListstrtoCSVline(s[i].Cells, c));
            }
            try
            {
                fprintf(path, se.ToArray(), rewrite, encode);

            }
            catch (CSVException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw new CSVException(null, e);
            }

        }

        #region Converters

        /// <summary>
        /// Convert form CSV line to String arr for rows
        /// </summary>
        /// <param name="s">Raw string</param>
        /// <param name="c">Separator between columns</param>
        /// <returns></returns>
        public static List<string> ConvertCSVlinetoListstr(string s, char c=',')
        {
            List<string> l = new List<string>();
            bool isquote = false;
            bool istrim = true;
            bool fs = true;
            string sn = "";
            for (int i = 0; i < s.Length; i++)
            {
                if(s[i]=='"' && (fs || i+1==s.Length || s[i + 1] != '"'))
                {
                    if (!isquote)
                    {
                        sn.TrimStart(' ');
                        istrim = false;
                    }
                    isquote ^= true;
                    if (fs) { fs = false; }
                    continue;
                }
                if(s[i]=='"' && i+1<s.Length && s[i + 1] == '"')
                {
                    sn += s[i];
                    ++i;
                    if (fs) { fs = false; }
                    continue;
                }
                if (isquote)
                {
                    sn += s[i];
                    if (fs) { fs = false; }
                    continue;
                }
                if (s[i] == c)
                {
                    if (istrim) { sn = sn.Trim(' ', '\n', '\t', '\r'); }
                    l.Add(sn);
                    sn = "";
                    isquote = false;
                    istrim = true;
                    fs = true;
                    continue;
                }
                if (!isquote)
                { 
                    sn += s[i];
                    if (fs) { fs = false; }
                    continue;
                }

            }
            if (sn.Length > 0) { l.Add(sn); }

            return l;
        }

        /// <summary>
        /// Convert form String arr from rows to CSV line
        /// </summary>
        /// <param name="s">List of string from colums</param>
        /// <param name="c">Separator between columns</param>
        /// <returns></returns>
        public static string ConvertListstrtoCSVline(List<string> s, char c = ',', bool always=false)
        {
            bool isquote = false;
            string sn = "",sr = "";

            
                
            for(int j = 0;j < s.Count; j++)
            {
                if (s[j] == null) { isquote = true; }
                for (int i = 0;s[j]!=null && i < s[j].Length; i++)
                {
                    if (s[j][i] == '"')
                    {
                        sn += '"';
                        sn += s[j][i];
                        isquote = true;
                        continue;
                    }
                    if (isquote)
                    {
                        sn += s[j][i];
                        continue;
                    }
                    if (s[j][i] == c)
                    {
                        sn += s[j][i];
                        isquote = true;
                        continue;
                    }
                    if (!isquote)
                    {
                        sn += s[j][i];
                        continue;
                    }
                }
                if (isquote || always) { sn = '"'+sn+'"'; }
                sr+=sn;
                sr+=c;
                sn = "";
                isquote = false;
            }
            sr = sr.Substring(0, Math.Max(0,sr.Length - 1));
            return sr;//.TrimEnd(c);
        }

        /// <summary>
        /// Convert form String arr from colums to CSV line
        /// </summary>
        /// <param name="s">List of string from colums</param>
        /// <param name="c">Separator between columns</param>
        /// <returns></returns>
        public static string ConvertListstrtoCSVline(System.Windows.Forms.DataGridViewCellCollection s, char c = ',', bool always = false)
        {
            bool isquote = false;
            string sn = "", sr = "";



            for (int j = 0; j < s.Count; j++)
            {

                if (s[j].Value == null) { isquote = true; }
                for (int i = 0; s[j].Value!=null && i < ((string)(s[j].Value)).Length; i++)
                {
                    if (((string)(s[j].Value))[i] == '"')
                    {
                        sn += '"';
                        sn += ((string)(s[j].Value))[i];
                        isquote = true;
                        continue;
                    }
                    if (isquote)
                    {
                        sn += ((string)(s[j].Value))[i];
                        continue;
                    }
                    if (((string)(s[j].Value))[i] == c)
                    {
                        sn += ((string)(s[j].Value))[i];
                        isquote = true;
                        continue;
                    }
                    if (!isquote)
                    {
                        sn += ((string)(s[j].Value))[i];
                        continue;
                    }
                }
                if (isquote || always) { sn = '"' + sn + '"'; }
                sr += sn;
                sr += c;
                sn = "";
                isquote = false;
            }
            sr = sr.Substring(0, Math.Max(0, sr.Length - 1));
            return sr;//.TrimEnd(c);
        }


        #endregion

        #region GetSeparatorType

        /// <summary>
        /// Return separator value of separator type
        /// </summary>
        /// <param name="s">Separator type</param>
        /// <returns></returns>
        public static char GetSeparType(string s)
        {
            switch (s[0])
            {
                case ('C'):
                        return ',';

                case ('T'):
                        return '\t';

                case ('S'):
                        return ';';
                    
            }
            return ',';
        }
        /// <summary>
        /// Return separator value of separator type
        /// </summary>
        /// <param name="s">Separator type</param>
        /// <returns></returns>
        public static char GetSeparType(char s)
        {
            switch (s)
            {
                case ('C'):
                        return ',';

                case ('T'):
                        return '\t';

                case ('S'):
                        return ';';
                    
            }
            return ',';
        }

        #endregion
    }
}
