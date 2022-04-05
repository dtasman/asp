using System;
using System.Diagnostics;
using System.Threading;
using FlaUI.Core;
using FlaUI.Core.Conditions;
using FlaUI.Core.Definitions;
using FlaUI.Core.Input;
using FlaUI.Core.WindowsAPI;
using FlaUI.Core.AutomationElements;
using FlaUI.UIA2;
using FlaUI.UIA3;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Testing
{
    [TestClass]
    public class Test1
    {
        private readonly string appPath = @"C:\Program Files\7-Zip\7zFM.exe";
        [TestMethod]
        public void Archiving()
        {
            var application = Application.Launch(appPath);
            var archive_name = "ZarchiwowanyFolder.7z";
            var folder_name = "FolderDoArchiwowania";
            var seconds = 2000;
            Thread.Sleep(200);
            var window = application.GetMainWindow(new UIA3Automation());

            ConditionFactory cf = new ConditionFactory(new UIA3PropertyLibrary());
            Assert.AreEqual(true, window.FindFirstDescendant(cf.ByAutomationId("1003")).IsAvailable);
            
            Thread.Sleep(seconds);
            window.FindFirstDescendant(cf.ByAutomationId("1003")).FindFirstChild().AsTextBox().Enter(@"");
            Keyboard.Press(VirtualKeyShort.ENTER);
            
            Thread.Sleep(seconds);
            window.FindFirstDescendant(cf.ByAutomationId("1003")).FindFirstChild().AsTextBox().Enter(@"D:\");
            Keyboard.Press(VirtualKeyShort.ENTER);
            
            Thread.Sleep(seconds);
            Assert.AreEqual(true, window.FindFirstDescendant(cf.ByName(folder_name)).IsAvailable);
            Keyboard.Type(folder_name);
            

            Thread.Sleep(seconds);
            window.FindFirstDescendant(cf.ByName("Add")).AsButton().Click();
            
            Thread.Sleep(seconds);
            Keyboard.Type(archive_name);
            
            Thread.Sleep(seconds);
            Keyboard.Press(VirtualKeyShort.ENTER);
            
            Thread.Sleep(seconds);
            Assert.AreEqual(true, window.FindFirstDescendant(cf.ByName(archive_name)).IsAvailable);
            Keyboard.Type(archive_name);
            
            Thread.Sleep(2 * seconds);
            window.Close();
        }
    }

    [TestClass]
    public class Test2
    {
        private readonly string appPath = @"C:\Program Files\7-Zip\7zFM.exe";
        [TestMethod]
        public void Extracting()
        {
            var application = Application.Launch(appPath);
            var archive_name = "ZarchiwowanyFolder.7z";
            var new_folder_name = "ZarchiwowanyFolder";
            var folder_name = "FolderDoArchiwowania";
            var seconds = 2000;
            Thread.Sleep(200);
            var window = application.GetMainWindow(new UIA3Automation());


            ConditionFactory cf = new ConditionFactory(new UIA3PropertyLibrary());

            Assert.AreEqual(true, window.FindFirstDescendant(cf.ByAutomationId("1003")).IsAvailable);

            Thread.Sleep(seconds);
            window.FindFirstDescendant(cf.ByAutomationId("1003")).FindFirstChild().AsTextBox().Enter(@"");
            Keyboard.Press(VirtualKeyShort.ENTER);

            Thread.Sleep(seconds);
            window.FindFirstDescendant(cf.ByAutomationId("1003")).FindFirstChild().AsTextBox().Enter(@"D:\");
            Keyboard.Press(VirtualKeyShort.ENTER);

            if (window.FindFirstDescendant(cf.ByName(new_folder_name)).IsAvailable)
            {
                Keyboard.Type(new_folder_name);
                Thread.Sleep(seconds);
                window.FindFirstDescendant(cf.ByName("Delete")).AsButton().Click();
                Thread.Sleep(seconds);
                Keyboard.Press(VirtualKeyShort.ENTER);
            }

            Thread.Sleep(seconds);
            Assert.AreEqual(true, window.FindFirstDescendant(cf.ByName(archive_name)).IsAvailable);
            Keyboard.Type(archive_name);

            Thread.Sleep(seconds);
            window.FindFirstDescendant(cf.ByName("Extract")).AsButton().Click();

            Thread.Sleep(seconds);
            Keyboard.Press(VirtualKeyShort.ENTER);

            Thread.Sleep(2*seconds);

            Assert.AreEqual(true, window.FindFirstDescendant(cf.ByName(new_folder_name)).IsAvailable);
            Keyboard.Type(new_folder_name);

            Thread.Sleep(seconds);
            window.FindFirstDescendant(cf.ByAutomationId("1003")).FindFirstChild().AsTextBox().Enter(String.Format(@"D:\{0}",
                         new_folder_name));

            Thread.Sleep(2*seconds);
            Keyboard.Press(VirtualKeyShort.ENTER);

            Thread.Sleep(seconds);
            Assert.AreEqual(true, window.FindFirstDescendant(cf.ByName(folder_name)).IsAvailable); 


            Thread.Sleep(2*seconds);
            window.Close();



        }
    }

    [TestClass]
    public class Test3
    {
        private readonly string appPath = @"C:\Program Files\7-Zip\7zFM.exe";
        [TestMethod]
        public void Deleting()
        {
            var application = Application.Launch(appPath);
            var archive_name = "ZarchiwowanyFolder.7z";
            var seconds = 2000;
            Thread.Sleep(200);
            var window = application.GetMainWindow(new UIA3Automation());

            ConditionFactory cf = new ConditionFactory(new UIA3PropertyLibrary());

            Assert.AreEqual(true, window.FindFirstDescendant(cf.ByAutomationId("1003")).IsAvailable);
            
            Thread.Sleep(seconds);
            window.FindFirstDescendant(cf.ByAutomationId("1003")).FindFirstChild().AsTextBox().Enter(@"");
            Keyboard.Press(VirtualKeyShort.ENTER);
            
            Thread.Sleep(seconds);
            window.FindFirstDescendant(cf.ByAutomationId("1003")).FindFirstChild().AsTextBox().Enter(@"D:\");
            Keyboard.Press(VirtualKeyShort.ENTER);
            
            Thread.Sleep(seconds);
            Assert.AreEqual(true, window.FindFirstDescendant(cf.ByName(archive_name)).IsAvailable);
            Keyboard.Type(archive_name);

            Thread.Sleep(seconds);
            window.FindFirstDescendant(cf.ByName("Delete")).AsButton().Click();

            Thread.Sleep(seconds);
            Keyboard.Press(VirtualKeyShort.ENTER);

            Thread.Sleep(2*seconds);
            Thread.Sleep(2 * seconds);
            window.Close();
        }
    }
}

