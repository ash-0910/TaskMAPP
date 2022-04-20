using Firebase.Auth;
using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskMAPP.Model;
using System.Linq;

namespace TaskMAPP
{
    public class Helper
    {
        FirebaseAuthProvider auth = new FirebaseAuthProvider(new Firebase.Auth.FirebaseConfig("AIzaSyAdIYhrybYn6uOm-2umGJYPw_on9zbrthU"));

        
        bool result;

        FirebaseClient firebaseDatabase = new FirebaseClient("https://finalproject-4e52e-default-rtdb.firebaseio.com");


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

        public async Task<List<Tasks>> GetAllTask()
        {
            var response =  (await firebaseDatabase.Child("Tasks").OnceAsync<Tasks>()).Select(item => new Tasks()
            {
                Email = item.Object.Email,
                TaskName = item.Object.TaskName

            }).ToList();

            return response;

        }
    }
}
