import 'bootstrap/dist/css/bootstrap.css';
import React from 'react';
import App from './App';
import * as ReactDOM from "react-dom";

const baseUrl = document.getElementsByTagName('base')[0].getAttribute('href');
const rootElement = document.getElementById('root');

ReactDOM.render(<App />, rootElement);


