using System.Collections.Generic;
using Sogeti.Academy.Application.Topics.Models;

namespace Sogeti.Academy.Application.Topics.Factories
{
	public interface ITopicFactory
	{
		Topic Create(string name);
	}

    public class TopicFactory : ITopicFactory
    {
        public Topic Create(string name)
        {
            return new Topic
			{
				Name = name
			};
        }
    }
}