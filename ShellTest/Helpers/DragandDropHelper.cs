using OpenQA.Selenium;

using ShellFramework.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShellTest.Helpers
{
   public  class DragandDropHelper
    {


        public static void DragandDrop( By drag, By drop)
        {
            try
            {

                // select = new SelectElement(GenericHelper.GetElement(locator));

                IWebElement drage = GenericHelper.GetElement(drag);

                IWebElement drope = GenericHelper.GetElement(drop);
                OpenQA.Selenium.Interactions.Actions action = new OpenQA.Selenium.Interactions.Actions(DriverContext.Driver);

                action.DragAndDrop(drage, drope).Build().Perform();





                //      (new Actions(DriverContext.Driver)).ClickAndHold(drage).MoveToElement(drope).DragAndDrop(drage, drope).Perform();

                //    (new Actions(DriverContext.Driver)).ClickAndHold(drage).MoveToElement(drope).Build().Perform();

            }
            catch (Exception)
            {
                //ignore
            }
        }
    }
}
