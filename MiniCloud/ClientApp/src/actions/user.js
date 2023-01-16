import axios from 'axios'

export const registration = async (email,name, password) => {
    try {
        const response = await axios.post(`http://localhost:5035/user/register`, {
            UserName: name,
            Email: email,
            Password:password
        })
        alert(response.data.message)
    } catch (e) {
        alert(e.response.data.message)
    }

}