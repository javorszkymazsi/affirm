using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace AffirmationsApp.Areas.Identity.Data;

// Add profile data for application users by adding properties to the AffirmationsAppUser class
public class AffirmationsAppUser : IdentityUser
{
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string PhotoURL { get; set; }

    public AffirmationsAppUser()
    {
        
    }
}

