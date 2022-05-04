import axios from "axios";

const baseUrl = "https://localhost:7076/api/";

export default {
    Person(url = baseUrl + 'Persons/'){
        return{
            getAll: () => axios.get(url),
            Create: newPerson => axios.post(url,newPerson),
            Delete: id => axios.delete(url + id)
        }
    }
}