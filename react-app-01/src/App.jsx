//import { useState } from 'react'
//import reactLogo from './assets/react.svg'
//import viteLogo from '/vite.svg'
import './App.css'

import { useState, useEffect } from 'react';
import axios from 'axios';

function App() {
    const [employees, setEmployees] = useState([]);

    useEffect(() => {
        axios.get('http://localhost:44397/Employees')
            .then(response => {
                // Z�sk�n� pole zam�stnanc� z odpov�di API
                const employeesArray = response.data.employees;
                // Nastaven� dat do stavu komponenty
                setEmployees(employeesArray);
            })
            .catch(error => {
                console.error('Chyba p�i z�sk�v�n� dat:', error);
            });
    }, []);

    return (
        <div>
            <h1>Seznam zamestnancu</h1>
            <ul>
                {employees.map(employee => (
                    <li key={employee.id}>{`${employee.firstName} ${employee.lastName}`}</li>
                ))}
            </ul>
        </div>
    );
}

export default App;

