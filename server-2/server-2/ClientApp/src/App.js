import React, { Component } from 'react';
import axios from 'axios';

import './custom.css'

export default class App extends Component {

  fetchRBC = async () => {
    console.log('lfnf')
    const url = 'https://www.cbr-xml-daily.ru/daily_json.js';

    const {data} = await axios.get(url);

    await axios.post('https://localhost:44359/api/CBR', {data: JSON.stringify(data)})
  }

  render () {
    return (
      <div>
          <button onClick={this.fetchRBC}>Начать цепочку</button>
      </div>
    );
  }
}
