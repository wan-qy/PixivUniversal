﻿//PixivUniversal
//Copyright(C) 2017 Pixeez Plus Project

//This program is free software; you can redistribute it and/or
//modify it under the terms of the GNU General Public License
//as published by the Free Software Foundation; version 2
//of the License.

//This program is distributed in the hope that it will be useful,
//but WITHOUT ANY WARRANTY; without even the implied warranty of
//MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//GNU General Public License for more details.

//You should have received a copy of the GNU General Public License
//along with this program; if not, write to the Free Software
//Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pixeez.Objects
{
    public class UserStats
    {

        [JsonProperty("works")]
        public int? Works { get; set; }

        [JsonProperty("favorites")]
        public int? Favorites { get; set; }

        [JsonProperty("following")]
        public int? Following { get; set; }

        [JsonProperty("friends")]
        public int? Friends { get; set; }
    }

    public class Contacts
    {

        [JsonProperty("twitter")]
        public string Twitter { get; set; }
    }

    public class Workspace
    {

        [JsonProperty("computer")]
        public string Computer { get; set; }

        [JsonProperty("monitor")]
        public string Monitor { get; set; }

        [JsonProperty("software")]
        public string Software { get; set; }

        [JsonProperty("scanner")]
        public string Scanner { get; set; }

        [JsonProperty("tablet")]
        public string Tablet { get; set; }

        [JsonProperty("mouse")]
        public string Mouse { get; set; }

        [JsonProperty("printer")]
        public string Printer { get; set; }

        [JsonProperty("on_table")]
        public string OnTable { get; set; }

        [JsonProperty("music")]
        public string Music { get; set; }

        [JsonProperty("table")]
        public string Table { get; set; }

        [JsonProperty("chair")]
        public string Chair { get; set; }

        [JsonProperty("other")]
        public string Other { get; set; }

        [JsonProperty("image_url")]
        public string ImageUrl { get; set; }

        [JsonProperty("image_urls")]
        public ImageUrls ImageUrls { get; set; }
    }

    public class Profile
    {

        [JsonProperty("contacts")]
        public Contacts Contacts { get; set; }

        [JsonProperty("workspace")]
        public Workspace Workspace { get; set; }

        [JsonProperty("job")]
        public string Job { get; set; }

        [JsonProperty("introduction")]
        public string Introduction { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("tags")]
        public object Tags { get; set; }

        [JsonProperty("homepage")]
        public string Homepage { get; set; }

        [JsonProperty("birth_date")]
        public string BirthDate { get; set; }

        [JsonProperty("blood_type")]
        public string BloodType { get; set; }
    }

    public class User
    {

        [JsonProperty("id")]
        public long? Id { get; set; }

        [JsonProperty("account")]
        public string Account { get; set; }

        [JsonProperty("mail_address")]
        public string Email { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("is_following")]
        public bool? IsFollowing { get; set; }

        [JsonProperty("is_follower")]
        public bool? IsFollower { get; set; }

        [JsonProperty("is_friend")]
        public bool? IsFriend { get; set; }

        [JsonProperty("is_premium")]
        public bool? IsPremium { get; set; }
        public bool? is_followed { get; set; }

        [JsonProperty("profile_image_urls")]
        public ProfileImageUrls ProfileImageUrls { get; set; }

        [JsonProperty("stats")]
        public UserStats Stats { get; set; }

        [JsonProperty("profile")]
        public Profile Profile { get; set; }
    }
}
