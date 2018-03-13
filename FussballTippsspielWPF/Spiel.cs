using Newtonsoft.Json;
using System;

namespace FussballTippsspielWPF
{

    public class Spiele
    {
        public Class1 Property1 { get; set; }
    }

    public class Class1
    {
        public int MatchID { get; set; }
        public DateTime MatchDateTime { get; set; }
        public string TimeZoneID { get; set; }
        public int LeagueId { get; set; }
        public string LeagueName { get; set; }
        public DateTime MatchDateTimeUTC { get; set; }
        public Group Group { get; set; }
        public Team1 Team1 { get; set; }
        public Team2 Team2 { get; set; }
        public DateTime LastUpdateDateTime { get; set; }
        public bool MatchIsFinished { get; set; }
        public Matchresult[] MatchResults { get; set; }
        public Goal[] Goals { get; set; }
        public Location Location { get; set; }
        public int? NumberOfViewers { get; set; }
    }

    public class Group
    {
        public string GroupName { get; set; }
        public int GroupOrderID { get; set; }
        public int GroupID { get; set; }
    }

    public class Team1
    {
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public string ShortName { get; set; }
        public string TeamIconUrl { get; set; }
    }

    public class Team2
    {
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public string ShortName { get; set; }
        public string TeamIconUrl { get; set; }
    }

    public class Location
    {
        public int LocationID { get; set; }
        public string LocationCity { get; set; }
        public string LocationStadium { get; set; }
    }

    public class Matchresult
    {
        public int ResultID { get; set; }
        public string ResultName { get; set; }
        public int PointsTeam1 { get; set; }
        public int PointsTeam2 { get; set; }
        public int ResultOrderID { get; set; }
        public int ResultTypeID { get; set; }
        public string ResultDescription { get; set; }
    }

    public class Goal
    {
        public int GoalID { get; set; }
        public int ScoreTeam1 { get; set; }
        public int ScoreTeam2 { get; set; }
        public int MatchMinute { get; set; }
        public int GoalGetterID { get; set; }
        public string GoalGetterName { get; set; }
        public bool IsPenalty { get; set; }
        public bool IsOwnGoal { get; set; }
        public bool IsOvertime { get; set; }
        public object Comment { get; set; }
    }



}

