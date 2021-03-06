﻿using System.Collections.Generic;
using System.Linq;

namespace shuffle.models
{
    public class GameContext
    {
        public ShuffleService ShuffleSvc { get; }

        public GameContext(int round)
        {
            var gameSetting = new GameSettingService().GetSetting();
            Round = round;
            Attendees = gameSetting.Attendees;
            Rule = gameSetting.Rule;
            ShuffleSvc = new ShuffleService();
        }


        public int Round { get; set; }
        public List<Attendee> Attendees { get; }

        public GameRule Rule { get; set; }

        public bool IsValid(out string msg)
        {
            var attendeesCount = Attendees.Count;
            var rolesCount = Rule.Role2Count.Values.Sum();
            if (attendeesCount != rolesCount)
            {
                msg = $"Attendees count does not match roles count. Attendees: {attendeesCount}, roles: {rolesCount}.";
                return false;
            }

            if (!string.IsNullOrEmpty(Rule.JudgeEmail) && !Attendees.Select(a => a.Email).Contains(Rule.JudgeEmail))
            {
                msg = $"Judge's email: {Rule.JudgeEmail} does not exist in attendees list, please check.";
                return false;
            }
            msg = string.Empty;
            return true;
        }

        public Game GetGame()
        {
            return new Game(Round++, ShuffleSvc.Shuffle(Attendees, Rule));
        }
    }
}