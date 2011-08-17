using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Globalization;

namespace SubscriptionBridge
{

    public class Utilities
    {

        public static string[] known_bad = {
			"*",
			"--",
			";--",
			";",
			"/*",
			"*/",
			"@@",
			"char",
			"nchar",
			"varchar",
			"nvarchar",
			"alter",
			"begin",
			"create",
			"cursor",
			"declare",
			"delete",
			"drop",
			"exec",
			"execute",
			"fetch",
			"insert",
			"kill",
			"open",
			"select",
			"sys",
			"sysobjects",
			"syscolumns",
			"table",
			"update",
			")",
			"(",
			"|",
			""

		};
        public string GetUserInput(string UserInput, int stringLength)
        {
            string functionReturnValue = null;

            string tempStr = "";
            int i = 0;

            if (stringLength > 0)
            {
                tempStr = UserInput.Substring(0, stringLength);
            }
            else
            {
                tempStr = UserInput.Trim();
            }

            if (string.IsNullOrEmpty(tempStr))
            {
                return "";
            }

            for (i = 0; i <= known_bad.Length - 1; i++)
            {
                if ((UserInput.IndexOf(known_bad[i], StringComparison.OrdinalIgnoreCase) >= 0))
                {
                    tempStr = tempStr.Replace(known_bad[i], "");
                }
            }

            tempStr = tempStr.Replace("%0d", "");
            tempStr = tempStr.Replace("%0D", "");
            tempStr = tempStr.Replace("%0a", "");
            tempStr = tempStr.Replace("%0A", "");
            tempStr = tempStr.Replace("\\r\\n", "");
            tempStr = tempStr.Replace("\\r", "");
            tempStr = tempStr.Replace("\\n", "");
            tempStr = tempStr.Replace("\\R\\N", "");
            tempStr = tempStr.Replace("\\R", "");
            tempStr = tempStr.Replace("\\N", "");
            tempStr = tempStr.Replace("EXEC(", "");

            functionReturnValue = tempStr;

            return functionReturnValue;

        }


        public static string removeInvalidXML(string element)
        {
            element = element.Replace("&", " and ");
            return element;
        }


        public static string hex_hmac_sha1(string key, string to_hash)
        {

            System.Security.Cryptography.HMACSHA1 hmac = new System.Security.Cryptography.HMACSHA1();
            hmac.Key = System.Text.Encoding.ASCII.GetBytes(key);
            hmac.ComputeHash(System.Text.Encoding.ASCII.GetBytes((string)to_hash));


            string _h = "";
            foreach (byte num in hmac.Hash)
            {
                _h += num.ToString("X02");
            }

            return _h;

        }



        public static string HashToken(string strMerchantPassword, string strMerchantKey)
        {
            string Token = null;

            SubscriptionAPI SubscriptionAPIObj = new SubscriptionAPI();
            string dt = SubscriptionAPIObj.GetTimeRequest();

            //// Password Digest
            //   -> PassWord|YYYYMMDD|HHMM
            Token = strMerchantPassword + "|" + dt;
            Token = hex_hmac_sha1(strMerchantKey, Token);

            return Token;
        }
    }


}
