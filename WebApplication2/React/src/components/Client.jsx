import React, { useState } from 'react';
import Header from "./Header";
import './Client.css';

const Client = ({ data, setData }) => {
    const [selectedValue, setSelectedValue] = useState("");
    const [nameInput, setNameInput] = useState("");

    const handleSelectChange = (event) => {
        const selectedIndex = event.target.selectedIndex;
        const selectedLabel = event.target[selectedIndex].label;
        setSelectedValue(selectedLabel);
    }

    const handleNameChange = (event) => {
        setNameInput(event.target.value);
    }

    const handleAddClick = () => {
        if (selectedValue !== "3" && nameInput !== "") {
            if (selectedValue === "1") {
                setSelectedValue("ИП")
            }
            else {
                setSelectedValue("ЮЛ")
            }
            const newData = {
                name: nameInput,
                type: selectedValue
            };

            fetch('https://localhost:7133/api/Client/CreateClient', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(newData)
            })
                .then(response => response.json())
                .then(newClient => {
                    setData([...data, newClient]);
                    setNameInput("");
                    setSelectedValue("");
                })
                .catch(error => {
                    console.error('Ошибка при добавлении клиента:', error);
                });
        }
    }

    return (
        <>
            <div className="head">
                <Header/>
            </div>
            <div className="container">
                <div className="table-container">
                    <div>
                        <label>Название:
                            <input className="input-name" type="text" maxLength="150" value={nameInput} onChange={handleNameChange}/>
                        </label>
                        <label className="lb-type">Тип:
                            <select className="select-type" defaultValue="0" onChange={handleSelectChange}>
                                <option className="selectField" value="0" disabled>Default</option>
                                <option className="selectField" value="1">ИП</option>
                                <option className="selectField" value="2">ЮЛ</option>
                            </select>
                        </label>
                        <div className="btn-container">
                            <button className="btn-add" onClick={handleAddClick}>Добавить клиента</button>
                        </div>
                    </div>

                    <ul className="table-column">
                        <div>INN</div>
                        <div>Название</div>
                        <div>Тип</div>
                        <div>Дата добавления</div>
                        <div>Дата обновления</div>
                    </ul>
                    <div className="table-rows">
                        {data.map((client, index) => (
                            <div key={index}>
                                <div>{client.inN_client}</div>
                                <div>{client.name}</div>
                                <div>{client.type}</div>
                                <div>{new Date(client.dateAdded).toLocaleDateString()}</div>
                                <div>{new Date(client.dateUpdated).toLocaleDateString()}</div>
                            </div>
                        ))}
                    </div>
                </div>
            </div>
        </>
    );
};

export default Client;