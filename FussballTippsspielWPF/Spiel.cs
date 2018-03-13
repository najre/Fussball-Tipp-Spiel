

namespace FussballTippsspielWPF
{
    using System;
    using System.Collections.Generic;
    using System.Net;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class SpielTag
    {
        [JsonProperty("MatchID")]
        public long MatchId { get; set; }

        [JsonProperty("MatchDateTime")]
        public System.DateTimeOffset MatchDateTime { get; set; }

        [JsonProperty("TimeZoneID")]
        public string TimeZoneId { get; set; }

        [JsonProperty("LeagueId")]
        public long LeagueId { get; set; }

        [JsonProperty("LeagueName")]
        public string LeagueName { get; set; }

        [JsonProperty("MatchDateTimeUTC")]
        public System.DateTimeOffset MatchDateTimeUtc { get; set; }

        [JsonProperty("Group")]
        public Group Group { get; set; }

        [JsonProperty("Team1")]
        public Team Team1 { get; set; }

        [JsonProperty("Team2")]
        public Team Team2 { get; set; }

        [JsonProperty("LastUpdateDateTime")]
        public System.DateTimeOffset LastUpdateDateTime { get; set; }

        [JsonProperty("MatchIsFinished")]
        public bool MatchIsFinished { get; set; }

        [JsonProperty("MatchResults")]
        public MatchResult[] MatchResults { get; set; }

        [JsonProperty("Goals")]
        public Goal[] Goals { get; set; }

        [JsonProperty("Location")]
        public Location Location { get; set; }

        [JsonProperty("NumberOfViewers")]
        public long? NumberOfViewers { get; set; }
    }

    public partial class Goal
    {
        [JsonProperty("GoalID")]
        public long GoalId { get; set; }

        [JsonProperty("ScoreTeam1")]
        public long ScoreTeam1 { get; set; }

        [JsonProperty("ScoreTeam2")]
        public long ScoreTeam2 { get; set; }

        [JsonProperty("MatchMinute")]
        public long MatchMinute { get; set; }

        [JsonProperty("GoalGetterID")]
        public long GoalGetterId { get; set; }

        [JsonProperty("GoalGetterName")]
        public string GoalGetterName { get; set; }

        [JsonProperty("IsPenalty")]
        public bool IsPenalty { get; set; }

        [JsonProperty("IsOwnGoal")]
        public bool IsOwnGoal { get; set; }

        [JsonProperty("IsOvertime")]
        public bool IsOvertime { get; set; }

        [JsonProperty("Comment")]
        public object Comment { get; set; }
    }

    public partial class Group
    {
        [JsonProperty("GroupName")]
        public string GroupName { get; set; }

        [JsonProperty("GroupOrderID")]
        public long GroupOrderId { get; set; }

        [JsonProperty("GroupID")]
        public long GroupId { get; set; }
    }

    public partial class Location
    {
        [JsonProperty("LocationID")]
        public long LocationId { get; set; }

        [JsonProperty("LocationCity")]
        public string LocationCity { get; set; }

        [JsonProperty("LocationStadium")]
        public string LocationStadium { get; set; }
    }

    public partial class MatchResult
    {
        [JsonProperty("ResultID")]
        public long ResultId { get; set; }

        [JsonProperty("ResultName")]
        public ResultName ResultName { get; set; }

        [JsonProperty("PointsTeam1")]
        public long PointsTeam1 { get; set; }

        [JsonProperty("PointsTeam2")]
        public long PointsTeam2 { get; set; }

        [JsonProperty("ResultOrderID")]
        public long ResultOrderId { get; set; }

        [JsonProperty("ResultTypeID")]
        public long ResultTypeId { get; set; }

        [JsonProperty("ResultDescription")]
        public ResultDescription ResultDescription { get; set; }
    }

    public partial class Team
    {
        [JsonProperty("TeamId")]
        public long TeamId { get; set; }

        [JsonProperty("TeamName")]
        public string TeamName { get; set; }

        [JsonProperty("ShortName")]
        public string ShortName { get; set; }

        [JsonProperty("TeamIconUrl")]
        public string TeamIconUrl { get; set; }
    }

    public enum ResultDescription { ErgebnisNachSpielende, ErgebnisZurHalbzeit };

    public enum ResultName { Endergebnis, Halbzeitergebnis };

    public partial class SpielTag
    {
        public static SpielTag[] FromJson(string json) => JsonConvert.DeserializeObject<SpielTag[]>(json, FussballTippsspielWPF.Converter.Settings);
    }

    static class ResultDescriptionExtensions
    {
        public static ResultDescription? ValueForString(string str)
        {
            switch (str)
            {
                case "Ergebnis nach Spielende": return ResultDescription.ErgebnisNachSpielende;
                case "Ergebnis zur Halbzeit": return ResultDescription.ErgebnisZurHalbzeit;
                default: return null;
            }
        }

        public static ResultDescription ReadJson(JsonReader reader, JsonSerializer serializer)
        {
            var str = serializer.Deserialize<string>(reader);
            var maybeValue = ValueForString(str);
            if (maybeValue.HasValue) return maybeValue.Value;
            throw new Exception("Unknown enum case " + str);
        }

        public static void WriteJson(this ResultDescription value, JsonWriter writer, JsonSerializer serializer)
        {
            switch (value)
            {
                case ResultDescription.ErgebnisNachSpielende: serializer.Serialize(writer, "Ergebnis nach Spielende"); break;
                case ResultDescription.ErgebnisZurHalbzeit: serializer.Serialize(writer, "Ergebnis zur Halbzeit"); break;
            }
        }
    }

    static class ResultNameExtensions
    {
        public static ResultName? ValueForString(string str)
        {
            switch (str)
            {
                case "Endergebnis": return ResultName.Endergebnis;
                case "Halbzeitergebnis": return ResultName.Halbzeitergebnis;
                default: return null;
            }
        }

        public static ResultName ReadJson(JsonReader reader, JsonSerializer serializer)
        {
            var str = serializer.Deserialize<string>(reader);
            var maybeValue = ValueForString(str);
            if (maybeValue.HasValue) return maybeValue.Value;
            throw new Exception("Unknown enum case " + str);
        }

        public static void WriteJson(this ResultName value, JsonWriter writer, JsonSerializer serializer)
        {
            switch (value)
            {
                case ResultName.Endergebnis: serializer.Serialize(writer, "Endergebnis"); break;
                case ResultName.Halbzeitergebnis: serializer.Serialize(writer, "Halbzeitergebnis"); break;
            }
        }
    }

    public static class Serialize
    {
        public static string ToJson(this SpielTag[] self) => JsonConvert.SerializeObject(self, FussballTippsspielWPF.Converter.Settings);
    }

    internal class Converter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(ResultDescription) || t == typeof(ResultName) || t == typeof(ResultDescription?) || t == typeof(ResultName?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (t == typeof(ResultDescription))
                return ResultDescriptionExtensions.ReadJson(reader, serializer);
            if (t == typeof(ResultName))
                return ResultNameExtensions.ReadJson(reader, serializer);
            if (t == typeof(ResultDescription?))
            {
                if (reader.TokenType == JsonToken.Null) return null;
                return ResultDescriptionExtensions.ReadJson(reader, serializer);
            }
            if (t == typeof(ResultName?))
            {
                if (reader.TokenType == JsonToken.Null) return null;
                return ResultNameExtensions.ReadJson(reader, serializer);
            }
            throw new Exception("Unknown type");
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var t = value.GetType();
            if (t == typeof(ResultDescription))
            {
                ((ResultDescription)value).WriteJson(writer, serializer);
                return;
            }
            if (t == typeof(ResultName))
            {
                ((ResultName)value).WriteJson(writer, serializer);
                return;
            }
            throw new Exception("Unknown type");
        }

        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                new Converter(),
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
