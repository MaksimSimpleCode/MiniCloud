import axios from 'axios'
import { setUser } from "../reducers/userReducer";

export const registration = async (email, password) => {
    try {
        const response = await axios.post(`http://localhost:5035/user/register`, {
            email,
            password
        })
        alert(response.data.message)
    } catch (e) {
        alert(e.response.data.message)
    }
}

export const login = (email, password) => {
    return async dispatch => {
        try {
            const response = await axios.post(`http://localhost:5035/user/authenticate`, {
                email,
                password
            })
            dispatch(setUser(response.data.email))
            localStorage.setItem('token', response.data.token)
        } catch (e) {
            alert("login " + e.response.data.message)
        }
    }
}

export const auth = () => {
    return async dispatch => {
        try {
            const response = await axios.get(`http://localhost:5035/user/auth`,
                { headers: { Authorization: `Bearer ${localStorage.getItem('token')}` } }
            )
            dispatch(setUser(response.data.email))
            localStorage.setItem('token', response.data.token)
        } catch (e) {
            alert("auth " + e.response.data.message)
            localStorage.removeItem('token')
        }
    }
}