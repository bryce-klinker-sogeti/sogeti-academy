import React from 'react';
import {loadTopics} from '../actions/TopicsActions';
import {CreateTopic} from './CreateTopic';
import {TopicsList} from './TopicsList';
import {TopicsStore} from '../stores/TopicsStore';

const topicsStore = new TopicsStore();
import '../styles/topics';
export class Topics extends React.Component {
    constructor(props, context) {
        super(props, context);
        
        this.state = {
            topics: topicsStore.getAll()
        };
        topicsStore.addChangeListener(this.onChange.bind(this));
        loadTopics();
    }
    
    onChange() {
        this.setState({
            topics: topicsStore.getAll()
        });
    }
    
    render() {
        return (
            <div className="topics">
                <div className="row">
                    <div className="col-sm-12">
                        <CreateTopic />
                    </div>
                </div>
                <div className="row">
                    <div className="col-sm-12">
                        <TopicsList topics={this.state.topics} />
                    </div>
                </div>
            </div>
        )
    }
}