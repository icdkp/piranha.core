/*
 * Copyright (c) 2018 Håkan Edling
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 * 
 * http://github.com/piranhacms/piranha
 * 
 */

using System.Security.Cryptography;
using System.Text;
using System.Text.Encodings;

namespace Piranha.AspNetCore.Identity
{
    public static class Utils
    {
		public static string GetGravatarUrl(string email, int size = 0) 
        {
            using (var md5 = MD5.Create())
            {
                var bytes = md5.ComputeHash(System.Text.Encoding.UTF8.GetBytes(email));

                var sb = new StringBuilder(bytes.Length * 2);
                for (int n = 0; n < bytes.Length; n++) {
                    sb.Append(bytes[n].ToString("X2"));
                }
                return "http://www.gravatar.com/avatar/" + sb.ToString().ToLower() +
                    (size > 0 ? "?s=" + size : "");
            }
		}        
    }
}