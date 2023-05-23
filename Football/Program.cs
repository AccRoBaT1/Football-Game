using System;
using System.Collections.Generic;
using static Football.Program;

namespace Football
{
    internal class Program
    {
        static string[] names = new string[]
            {
            "John Smith",
            "Jane Johnson",
            "Michael Davis",
            "Emily Wilson",
            "Daniel Brown",
            "Sarah Martinez",
            "David Anderson",
            "Olivia Taylor",
            "Matthew Thomas",
            "Emma Lee",
            "Christopher Moore",
            "Sophia Clark",
            "Andrew Rodriguez",
            "Ava Lewis",
            "James Lee",
            "Isabella Hernandez",
            "Joseph Walker",
            "Mia Martin",
            "William White",
            "Abigail Allen",
            "Ryan Young",
            "Madison Turner"
            };

        static void Main(string[] args)
        {
            PlayGame();
        }

        public static void PlayGame()
        {
            List<string> nameList1 = GetRandomNames(11);
            List<string> nameList2 = GetRandomNames(11);

            // The limit of 11 players could be set by a constructor in the Team class but it doesnt seem necessary as we can just do it from main right?
            // Example values to test out the Classes and the Class logic

            Team teamOne = new Team();
            for (int i = 1; i <= 11; i++)
            {
                if (i < 1)
                {
                    Goalkeeper player = new Goalkeeper
                    {
                        Name = nameList1[i-1],
                        Age = GenerateNumber(20, 25),
                        Number = i,
                        Height = GenerateNumber(165, 185)
                    };
                    teamOne.Players.Add(player);
                }
                else if (i <= 4)
                {
                    Defender player = new Defender
                    {
                        Name = nameList1[i-1],
                        Age = GenerateNumber(20, 25),
                        Number = i,
                        Height = GenerateNumber(165, 185)
                    };
                    teamOne.Players.Add(player);
                }
                else if (i > 4 && i <= 9)
                {
                    Midfield player = new Midfield
                    {
                        Name = nameList1[i-1],
                        Age = GenerateNumber(20, 25),
                        Number = i,
                        Height = GenerateNumber(165, 185)
                    };
                    teamOne.Players.Add(player);
                }
                else
                {
                    Striker player = new Striker
                    {
                        Name = nameList1[i-1],
                        Age = GenerateNumber(20, 25),
                        Number = i,
                        Height = GenerateNumber(165, 185)
                    };
                    teamOne.Players.Add(player);
                }
            }
            teamOne.Coach = new Coach { Name = "TeamOneCoach", Age = 50 };

            Team teamTwo = new Team();
            for (int i = 1; i <= 11; i++)
            {
                if (i < 1)
                {
                    Goalkeeper player = new Goalkeeper
                    {
                        Name = nameList2[i-1],
                        Age = GenerateNumber(20, 25),
                        Number = i,
                        Height = GenerateNumber(165, 185)
                    };
                    teamTwo.Players.Add(player);
                }
                else if (i <= 4)
                {
                    Defender player = new Defender
                    {
                        Name = nameList2[i-1],
                        Age = GenerateNumber(20, 25),
                        Number = i,
                        Height = GenerateNumber(165, 185)
                    };
                    teamTwo.Players.Add(player);
                }
                else if (i > 4 && i <= 9)
                {
                    Midfield player = new Midfield
                    {
                        Name = nameList2[i-1],
                        Age = GenerateNumber(20, 25),
                        Number = i,
                        Height = GenerateNumber(165, 185)
                    };
                    teamTwo.Players.Add(player);
                }
                else
                {
                    Striker player = new Striker
                    {
                        Name = nameList2[i-1],
                        Age = GenerateNumber(20, 25),
                        Number = i,
                        Height = GenerateNumber(165, 185)
                    };
                    teamTwo.Players.Add(player);
                }
            }
            teamTwo.Coach = new Coach { Name = "TeamTwoCoach", Age = 50 };

            Person[] assistantReferees = new Person[2];
            assistantReferees[0] = new Person
            {
                Name = "AssistRefereeOne",
                Age = 28
            };

            assistantReferees[1] = new Person
            {
                Name = "AssistRefereeTwo",
                Age = 25
            };

            List<Goal> myGoals = new List<Goal>();
            for (int i = 0; i < GenerateNumber(1, 4); i++)
            {
                Goal newGoal = new Goal
                {
                    Minute = GenerateNumber(1, 90),
                    Player = teamOne.Players[GenerateNumber(0, (teamOne.Players.Count) - 1)],
                    Team = teamOne
                };
                myGoals.Add(newGoal);
            }

            for (int i = 0; i < GenerateNumber(1, 4); i++)
            {
                Goal newGoal = new Goal
                {
                    Minute = GenerateNumber(1, 90),
                    Player = teamTwo.Players[GenerateNumber(0, (teamTwo.Players.Count) - 1)],
                    Team = teamTwo
                };
                myGoals.Add(newGoal);
            }

            Game myGame = new Game
            {
                Team1 = teamOne,
                Team2 = teamTwo,
                Referee = new Referee { Name = "Referee", Age = 33 },
                AssistantReferees = assistantReferees,
                Goals = myGoals
            };
            myGame.Winner = myGame.CalcResult(teamOne, teamTwo);
            myGame.Result = myGame.GameResult();

            Console.WriteLine(myGame.Result);
        }

        public static int GenerateNumber(int minValue, int maxValue)
        {
            Random random = new Random();
            return random.Next(minValue, maxValue + 1);
        }

        public static List<string> GetRandomNames(int count)
        {
            Random random = new Random();
            List<string> randomNames = new List<string>();

            string[] availableNames = (string[])names.Clone();

            for (int i = 0; i < count; i++)
            {
                int index = random.Next(0, availableNames.Length);
                string randomName = availableNames[index];

                availableNames[index] = availableNames[availableNames.Length - 1];
                Array.Resize(ref availableNames, availableNames.Length - 1);

                randomNames.Add(randomName);
            }

            return randomNames;
        }

        public class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }

        public class FootballPlayer : Person
        {
            public int Number { get; set; }
            public double Height { get; set; }
            public string Role { get; set; }
        }

        public class Goalkeeper : FootballPlayer
        {
            public Goalkeeper()
            {
                Role = "GOALKEEPER";
            }
        }

        public class Defender : FootballPlayer
        {
            public Defender()
            {
                Role = "DEFENDER";
            }
        }

        public class Midfield : FootballPlayer
        {
            public Midfield()
            {
                Role = "MIDFIELD";
            }
        }

        public class Striker : FootballPlayer
        {
            public Striker()
            {
                Role = "STRIKER";
            }
        }

        public class Coach : Person { }

        public class Referee : Person { }

        public class Team
        {
            public Coach Coach { get; set; }
            public List<FootballPlayer> Players = new List<FootballPlayer>();

            public double GetAveragePlayerAge()
            {
                int totalAge = 0;

                foreach (var player in Players)
                {
                    totalAge += player.Age;
                }

                return (double)totalAge / Players.Count;
            }
        }

        public class Goal
        {
            public int Minute { get; set; }
            public FootballPlayer Player { get; set; }
            public Team Team { get; set; }
        }

        public class Game
        {
            public Team Team1 { get; set; }
            public Team Team2 { get; set; }
            public Referee Referee { get; set; }
            public Person[] AssistantReferees { get; set; }
            public List<Goal> Goals = new List<Goal>();
            public string Result { get; set; }
            public Team Winner { get; set; }
            bool draw = false;

            public string GameResult()
            {
                Result = "Game result:\n";
                Goals.Sort((goal1, goal2) => goal1.Minute.CompareTo(goal2.Minute));

                for (int i = 0; i < Goals.Count; i++)
                {
                    if (Goals[i].Team == Team1)
                    {
                        Result += "\n  Goal " + (i + 1) + " | time: " + Goals[i].Minute + "m. | scored by: " + Goals[i].Player.Name + " | role: " + Goals[i].Player.Role + " | team: TeamOne";
                    } else
                    {
                        Result += "\n  Goal " + (i + 1) + " | time: " + Goals[i].Minute + "m. | scored by: " + Goals[i].Player.Name + " | role: " + Goals[i].Player.Role + " | team: TeamTwo";
                    }
                }


                if (this.draw)
                {
                    Result += "\n\nGame is DRAW!";
                } else
                {
                    if (Winner == Team1)
                    {
                        Result += "\n\nWinner: TeamOne";
                    }
                    else Result += "\n\nWinner: TeamTwo";
                }

                return Result;
            }

            public Team CalcResult(Team teamOne, Team teamTwo)
            {
                int teamOneGoals = 0, teamTwoGoals = 0;
                for (int i = 0; i < Goals.Count; i++)
                {
                    if (Goals[i].Team == teamOne)
                    {
                        teamOneGoals++;
                    }
                    else
                    {
                        teamTwoGoals++;
                    }
                }

                if (teamOneGoals > teamTwoGoals)
                {
                    return teamOne;
                } else if (teamOneGoals < teamTwoGoals)
                {
                    return teamTwo;
                } else
                {
                    this.draw = true;
                    return teamOne;
                }
            }
        }
    }
}
