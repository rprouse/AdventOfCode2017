﻿using System.Linq;
using NUnit.Framework;

namespace AdventOfCode2017.Test
{
    public class Day9Tests
    {
        [TestCase("Day9.txt", 12803)]
        public void FindSolution(string filename, int expected)
        {
            var str = Day9.ReadSomething(filename).First();
            Assert.That(str.ScoreGroups(), Is.EqualTo(expected));
        }

        [TestCase("<>")]
        [TestCase("<random characters>")]
        [TestCase("<<<<>")]
        [TestCase("<{!>}>")]
        [TestCase("<!!>")]
        [TestCase("<!!!>>")]
        [TestCase("<{o\"i!a,<{i<a>")]
        public void CanStripGarbage(string line)
        {
            Assert.That(line.StripGarbage(), Is.EqualTo(""));
        }

        [TestCase("{}", 1)]
        [TestCase("{{{}}}", 6)]
        [TestCase("{{},{}}", 5)]
        [TestCase("{{{},{},{{}}}}", 16)]
        [TestCase("{<a>,<a>,<a>,<a>}", 1)]
        [TestCase("{{<ab>},{<ab>},{<ab>},{<ab>}}", 9)]
        [TestCase("{{<!!>},{<!!>},{<!!>},{<!!>}}", 9)]
        [TestCase("{{<a!>},{<a!>},{<a!>},{<ab>}}", 3)]
        public void CanScoreGroups(string line, int expected)
        {
            Assert.That(line.ScoreGroups(), Is.EqualTo(expected));
        }
    }
}
