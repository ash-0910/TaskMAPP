using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TaskMAPP
{
    public class Helper
    {
        FirebaseAuthProvider auth = new FirebaseAuthProvider(new Firebase.Auth.FirebaseConfig("AIzaSyAdIYhrybYn6uOm-2umGJYPw_on9zbrthU"));

        bool result;


        public async Task<bool> FirebaseLogin(string email, string password)
        {

            var accounts = await auth.GetLinkedAccountsAsync(email);

            if (!accounts.IsRegistered)
            {
                result = false;
            }
            else
            {
                var registerauth = await auth.SignInWithEmailAndPasswordAsync(email, password);

                string token = registerauth.FirebaseToken;

                if (token != null)
                {
                    result = true;
                }
            }

            return result;
        }

        public async Task<bool> ResetPassword(string email)
        {

            var accounts = await auth.GetLinkedAccountsAsync(email);

            if (!accounts.IsRegistered)
            {
                result = false;
            }
            else
            {
                await auth.SendPasswordResetEmailAsync(email);

                result = true;
                
            }

            return result;

        }
    }
}
