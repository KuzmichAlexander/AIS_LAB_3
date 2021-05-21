import React, {Component, useEffect} from 'react';

import './custom.css'
import axios from "axios";

export const App = () => {

    useEffect(() => {
        const socket = new WebSocket('ws://localhost:777')
        socket.onmessage = (event) => {
            console.log(event.data)
            const data = JSON.parse(event.data)
            axios.post('https://localhost:44370/api/takeSoketDBSave', {data})
        }
    }, [])

    return (
        <p>Промежуточное звено</p>
    );
}
