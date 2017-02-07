
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LifeOfGame.Library;
using NUnit.Framework;

namespace LifeOfGames.Library.Tests
{
    [TestFixture]
    public class LifeRulesTests
    {
        [Test]
        public void LiveCell_FewerThan2LiveNeighbors_Dies([Values(0,1)] int liveNeighbors)
        {
            var currentState = CellState.Alive;
            CellState newState = LifeRules.GetNewState(currentState, liveNeighbors);
            Assert.AreEqual(CellState.Dead, newState);
        }

        [Test]
        public void LiveCell_2Or3LiveNeighbors_Lives([Values(2, 3)] int liveNeighbors)
        {
            var currentState = CellState.Alive;
            CellState newState = LifeRules.GetNewState(currentState, liveNeighbors);
            Assert.AreEqual(CellState.Alive, newState);
        }

        [Test]
        public void LiveCell_MoreThan3LiveNeighbors_Dies([Range(4,8)] int liveNeighbors)
        {
            var currentState = CellState.Alive;
            CellState newState = LifeRules.GetNewState(currentState, liveNeighbors);
            Assert.AreEqual(CellState.Dead, newState);
        }

        [Test]
        public void DeadCell_Exactly3LiveNeighbors_Lives()
        {
            int liveNeighbors = 3;
            var currentState = CellState.Dead;
            CellState newState = LifeRules.GetNewState(currentState, liveNeighbors);
            Assert.AreEqual(CellState.Alive, newState);
        }

        [Test]
        public void DeadCell_FewerThan3LiveNeighbors_StaysDead([Range(0,2)] int liveNeighbors)
        {
            var currentState = CellState.Dead;
            CellState newState = LifeRules.GetNewState(currentState, liveNeighbors);
            Assert.AreEqual(CellState.Dead, newState);
        }

        [Test]
        public void DeadCell_MoreThan3LiveNeighbors_StaysDead([Range(4, 8)] int liveNeighbors)
        {
            var currentState = CellState.Dead;
            CellState newState = LifeRules.GetNewState(currentState, liveNeighbors);
            Assert.AreEqual(CellState.Dead, newState);
        }
        [Test]
        public void CurrentState_When2_ThrowArgumentException()
        {
            var currentState = (CellState)2;
            var liveNeighbors = 0;

            CellState newState;
            //Assert.That(() => newState = LifeRules.GetNewState(currentState, liveNeighbors),
            //    Throws.TypeOf<ArgumentOutOfRangeException>());

            Assert.Throws<ArgumentOutOfRangeException>(() => newState = LifeRules.GetNewState(currentState, liveNeighbors));


        }
    }
}
