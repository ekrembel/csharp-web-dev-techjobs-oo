using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechJobsOO;
using System;

namespace TechJobsTests
{
    [TestClass]
    public class JobTests
    {

        [TestMethod]
        public void TestSettingJobId()
        {
            Job job1 = new Job();
            Job job2 = new Job();
            int jobOneId = job1.Id;
            int jobTwoId = job2.Id;
            Assert.IsTrue(jobTwoId == jobOneId + 1);
        }

        [TestMethod]
        public void TestJobConstructorSetsAllFields()
        {
            Job job = new Job("Product tester", new Employer("ACME"), new Location("Desert"), new PositionType("Quality control"), new CoreCompetency("Persistence"));
            Assert.AreEqual("Product tester", job.Name);
            Assert.AreEqual("ACME", job.EmployerName.Value);
            Assert.AreEqual("Desert", job.EmployerLocation.Value);
            Assert.AreEqual("Quality control", job.JobType.Value);
            Assert.AreEqual("Persistence", job.JobCoreCompetency.Value);
        }

        [TestMethod]
        public void TestJobsForEquality()
        {
            Job job1 = new Job("Web Developer", new Employer("LaunchCode"), new Location("St. Louis"), new PositionType("Front-end developer"), new CoreCompetency("JavaScript"));
            Job job2 = new Job("Web Developer", new Employer("LaunchCode"), new Location("St. Louis"), new PositionType("Front-end developer"), new CoreCompetency("JavaScript"));
            Assert.IsFalse(job1.Id == job2.Id);
        }

        [TestMethod]
        public void TestToStringBlankLines()
        {
            Job job = new Job("Web Developer", new Employer("LaunchCode"), new Location("St. Louis"), new PositionType("Front-end developer"), new CoreCompetency("JavaScript"));
            string str = job.ToString();
            Assert.AreEqual("\n", str.Substring(0,1));
            Assert.AreEqual("\n", str.Substring(str.Length - 1, 1));
        }

        [TestMethod]
        public void TestToStringContainsLabels()
        {
            Job job = new Job("Web Developer", new Employer("LaunchCode"), new Location("St. Louis"), new PositionType("Front-end developer"), new CoreCompetency("JavaScript"));
            string str = job.ToString();
            Assert.IsTrue(str.Contains("\nID: "));
            Assert.IsTrue(str.Contains("\nName: "));
            Assert.IsTrue(str.Contains("\nEmployer: "));
            Assert.IsTrue(str.Contains("\nLocation: "));
            Assert.IsTrue(str.Contains("\nPosition Type: "));
            Assert.IsTrue(str.Contains("\nCoreCompetency: "));
        }

        [TestMethod]
        public void TestToStringEmptyJob()
        {
            Job job = new Job("", new Employer(""), new Location(""), new PositionType(""), new CoreCompetency(""));
            Assert.AreEqual("OOPS! This job does not seem to exist.", job.ToString());
        }

        [TestMethod]
        public void TestToStringEmptyField()
        {
            Job job = new Job("Web Developer", new Employer(""), new Location(""), new PositionType(""), new CoreCompetency(""));
            Job job1 = new Job("", new Employer("LaunchCode"), new Location("St. Louis"), new PositionType("Front-end developer"), new CoreCompetency("JavaScript"));

            Assert.AreEqual("\nID: " + job.Id.ToString() + "\nName: " + job.Name + "\nEmployer: " + "Data not available" + "\nLocation: " + "Data not available" + "\nPosition Type: " + "Data not available" + "\nCoreCompetency: " + "Data not available" + "\n", job.ToString());
            Assert.AreEqual("\nID: " + job1.Id.ToString() + "\nName: " + "Data not available" + "\nEmployer: " + job1.EmployerName.Value + "\nLocation: " + job1.EmployerLocation.Value + "\nPosition Type: " + job1.JobType.Value + "\nCoreCompetency: " + job1.JobCoreCompetency.Value + "\n", job1.ToString());
        }
    }
}
