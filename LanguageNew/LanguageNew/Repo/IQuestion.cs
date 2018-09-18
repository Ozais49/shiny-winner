using LanguageNew.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageNew.Repo
{
    public interface IQuestion : IRepo<Questions>
    {
        string GetImage(int id);
     
    }
}
