import React from 'react';
import {render} from 'react-dom';
import {Router, Route, IndexRoute, hashHistory} from 'react-router';
import {App} from './app/components/App';
import {Home} from './home/components/Home';
import {Topics} from './topics/components/Topics';
import {Tooling} from './tooling/components/Tooling';

render(
    <Router history={hashHistory}>
        <Route path="/" component={App}>
            <IndexRoute component={Home} />
            <Route path="/topics" component={Topics} />
            <Route path="/tooling" component={Tooling} />
        </Route>
    </Router>,
    document.getElementById('app')
);