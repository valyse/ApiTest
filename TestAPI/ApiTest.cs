using Microsoft.VisualStudio.TestTools.UnitTesting;
using VkNet.Enums.Filters;
using VkNet.Model;

namespace TestAPI
{
    [TestClass]
    public class ApiTest
    {
        private City hometown;

        [TestMethod]
        public void CheckSPbFriends()
        {

            var api = new VkNet.VkApi();
            api.Authorize(new ApiAuthParams
            {
                AccessToken = "2583689c8e583ccb25b4b825b5795f904cedae4e8b96e585e0be83c1abf27a51551ad528674842e18d339"
            });

            VkNet.Utils.VkCollection<User> friends = api.Friends.Get(new VkNet.Model.RequestParams.FriendsGetParams
            {
                UserId = 4599649,
                Fields = ProfileFields.City,
            });

            hometown = api.Account.GetProfileInfo().City;
            int count = 0;
            
            foreach (var f in friends)
            {
                if (f.City == null)
                    continue;

                if (f.City.Title == hometown.Title)
                {
                    count++;
                }
            }

            Assert.AreEqual(count, 48);
        }
    }
}