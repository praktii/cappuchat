﻿using System;
using System.Collections.Generic;

namespace Chat.Shared.Models
{
    public class SimpleVote
    {
        private readonly Dictionary<string, int> _voteAnswerCache = new Dictionary<string, int>();

        public string CreatorName { get; set; }

        public string Question { get; set; }

        public IEnumerable<string> Answers { get; set; }

        public SimpleVote(string question, string creatorName, params string[] answers)
        {
            if (string.IsNullOrWhiteSpace(question))
                throw new ArgumentNullException(nameof(question), "Cannot create SimpleVote. Given question is invalid.");
            Question = question;

            if (creatorName == null)
                throw new ArgumentNullException(nameof(creatorName), "Cannot create SimpleVote. Given creatorName is null.");
            CreatorName = creatorName;

            Answers = answers;
        }

        public bool Vote(string username, int answerId)
        {
            if (!_voteAnswerCache.ContainsKey(username))
                _voteAnswerCache.Add(username, answerId);
            return !_voteAnswerCache.ContainsKey(username);
        }
    }
}
