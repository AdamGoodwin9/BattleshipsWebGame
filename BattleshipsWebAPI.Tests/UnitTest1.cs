using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BattleshipsWebAPI.Controllers;

namespace BattleshipsWebAPI.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void RegisterInvokeTest()
        {
            UserController controller = new UserController();
            var userInfo = controller.Register("test");
            Assert.IsNotNull(userInfo);
            //Assert.IsN

        }
    }
}
