﻿using Microsoft.AspNet.Mvc;
using Sogeti.Academy.Mvc.Tooling.Controllers;
using Xunit;

namespace Mvc.Test.Tooling.Controllers
{
    public class ToolingControllerTest
    {
        private readonly ToolingController _toolingController;

        public ToolingControllerTest()
        {
            _toolingController = new ToolingController();
        }

        [Fact]
        public void Index_ShouldReturnView()
        {
            var result = _toolingController.Index();
            Assert.IsType<ViewResult>(result);
        }
    }
}
