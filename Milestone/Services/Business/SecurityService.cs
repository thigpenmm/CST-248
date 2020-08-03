using Minesweeper.Controllers;
using Minesweeper.Models;
using Minesweeper.Services.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Minesweeper.Services.Business
{
    public class SecurityService
    {

        public bool login(User user)
        {

            UserDAO dao = new UserDAO();

            return dao.findByUser(user);
        }

        public bool register(User user)
        {

            UserDAO dao = new UserDAO();

            return dao.Register(user);
        }

    }
}