import React, {useState} from "react";
import './Founder.css';

const Founder = ({dataFounder, data, setData}) => {

    const [errorMessage, setErrorMessage] = useState("");
    const [innClient, setInnClient] = useState("");
    const [famInput, setFamInput] = useState("");
    const [nameInput, setNameInput] = useState("");
    const [surnameInput, setSurnameInput] = useState("");
    const handleInnInputChange = (event) => {
        setInnClient(event.target.value);
        const isClientExists = data.some(founder => founder.inN_client === innClient);
        if (isClientExists === false) {
            setErrorMessage(404);
        }
    }
    const handleFamChange = (event) => {
        setFamInput(event.target.value);
    }
    const handleNameChange = (event) => {
        setNameInput(event.target.value);
    }
    const handleSurnameChange = (event) => {
        setSurnameInput(event.target.value);//
    }
    const handleAddClick = () => {
        if (innClient !== "" && famInput !== "" && surnameInput !== "") {
            const newData = {
                inN_client: innClient,
                lastName: famInput,
                firstName: nameInput,
                surname: surnameInput,
            };

            fetch('https://localhost:7133/api/Founder/CreateFounders', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(newData)
            })
                .then(response => response.json())
                .then(newClient => {
                    setData([...data, newClient]);

                })
                .catch(error => {
                    console.error('Ошибка при добавлении учредителя:', error);
                });
        }
    }

    return (
        <div>
            <div className="container">
                <div className="table-container">
                    <div>
                        <label>ИНН клиента:
                            <input className="input-inn" type="text" maxLength="12" value={innClient} onChange={handleInnInputChange}/>
                        </label>
                        <label className="lable-type" onChange={handleFamChange}>Фамилия:
                            <input className="input-fam" type="text" maxLength="150"/>
                        </label>
                        <label className="lable-type" onChange={handleNameChange}>Имя:
                            <input className="input-name" type="text" maxLength="150"/>
                        </label >
                        <label className="lable-type" onChange={handleSurnameChange}>Отчество:
                            <input className="input-surname" type="text" maxLength="150"/>
                        </label>
                        <div className="btn-container">
                            <button className="btn-add" onClick={handleAddClick}>Добавить учредителя</button>
                        </div>
                    </div>

                    <ul className="table-column">
                        <div>INN_учредителя</div>
                        <div>INN_клиента</div>
                        <div>Фамилия</div>
                        <div>Имя</div>
                        <div>Отчество</div>
                        <div>Дата добавления</div>
                        <div>Дата обновления</div>
                    </ul>
                    <div className="table-rows">
                        {dataFounder.map((founder, index) => (
                            <div key={index}>
                                <div>{founder.inN_founder}</div>
                                <div>{founder.inN_client}</div>
                                <div>{founder.lastName}</div>
                                <div>{founder.firstName}</div>
                                <div>{founder.surname}</div>
                                <div>{new Date(founder.dateAdded).toLocaleDateString()}</div>
                                <div>{new Date(founder.dateUpdated).toLocaleDateString()}</div>
                            </div>
                        ))}
                    </div>
                </div>
            </div>
        </div>
    );
}

export default Founder;