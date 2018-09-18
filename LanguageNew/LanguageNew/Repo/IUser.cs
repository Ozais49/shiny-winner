using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LanguageNew.Models;

namespace LanguageNew.Repo
{
    interface IUser:IRepo<UserTable>
    {
        int validateUser(UserTable model);
        void insertLoginSuccess(string Username,string UserAgent);
    }
}
