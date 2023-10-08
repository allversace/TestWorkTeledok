import React, { useEffect, useState } from 'react';
import Client from "./components/Client";
import Founder from "./components/Founder";

const App = () => {
    const [data, setData] = useState([]);
    const [dataFounder, setDataFounder] = useState([]);

    useEffect(() => {
        fetch('https://localhost:7133/api/Client/GetClients')
            .then(response => response.json())
            .then(data => setData(data));
    }, []);

    useEffect(() => {
        fetch('https://localhost:7133/api/Founder/GetFounders')
            .then(response => response.json())
            .then(dataFounder => setDataFounder(dataFounder));
    }, []);

    return (
        <div>
            <Client data={data} />
            <Founder dataFounder={dataFounder} data={data}/>
        </div>
    );
};

export default App;
